using UnityEngine;
using System.Collections;

public class TriangularMapCreator : MonoBehaviour {
	public GameObject point, point2, point3, point4, accelerator,timebonus,triangle;
	public int objectsNumber;
	public int min, max;
	public float time;
	private int k, currentPoint;
	private float passedTime, pointsSize;
	private GameObject[] gameObjects, points;
	
	void Start(){
		points = new GameObject[] {point,point2,point3,point4};
		pointsSize = 0.6f;
		gameObjects = new GameObject[objectsNumber];
		for (int k=0; k<objectsNumber; k++) {
			Random.seed=(int)System.DateTime.Now.Ticks;
			
			gameObjects[k]=(GameObject)Instantiate (points[Random.Range(0,4)], GeneratedPosition(1), Quaternion.identity);
				}
		for (int j=0; j<2; j++) {
						Instantiate (timebonus, GeneratedPosition (0.6855319f), Quaternion.identity);
				}
	}
	
	void Update(){
		//        pointsAlpha = gameObjects [1].renderer.material.color.a;
		passedTime += Time.deltaTime;
		
		
		
		
		if (passedTime >= time - 1) {
		
			if (pointsSize > 0.0f) {
				
				gameObjects [currentPoint+1].transform.localScale -= new Vector3 (0.05f, 0.05f, 0.05f);
				pointsSize -= 0.05f;
				
			} else { 
				
				Component halo = gameObjects [currentPoint+1].GetComponent ("Halo");
				halo.GetType ().GetProperty ("enabled").SetValue (halo, false, null);

			}

		} else {
			if (pointsSize < 0.6f) {
				
				gameObjects [currentPoint].transform.localScale += new Vector3 (0.05f, 0.05f, 0.05f);
				pointsSize += 0.05f;
				
			}
			
			else { 
				
				Component halo = gameObjects [currentPoint].GetComponent ("Halo");
				halo.GetType ().GetProperty ("enabled").SetValue (halo, true, null);
				if(currentPoint>=(objectsNumber-1)) currentPoint=0;
			}
			
		}
//		
		if (passedTime >= time) {
			passedTime = 0;
			//gameObjects =  GameObject.FindGameObjectsWithTag ("Point");
			currentPoint++;
			if(currentPoint>=(objectsNumber-1)){
				Destroy(gameObjects[currentPoint]);
				PlacePoints (currentPoint);
				//currentPoint=0;
			}
			
			if(gameObjects[currentPoint]!=null)
			{
				Destroy(gameObjects[currentPoint]);
				gameObjects[currentPoint]=null;
			}
			
			PlacePoints (currentPoint);
		}
	}
	
	void PlacePoints(int i){
		Random.seed=(int)System.DateTime.Now.Ticks;
		
		gameObjects[i]=(GameObject)Instantiate (points[Random.Range(0,4)], GeneratedPosition(1), Quaternion.identity); //tu mozna dorzucic bonusy                                       }
		gameObjects [i].transform.localScale = new Vector3 (0, 0, 0);
		pointsSize=0;
		
	}
	
	Vector3 GeneratedPosition(float y){
		int x,z;
		Random.seed=(int)System.DateTime.Now.Ticks;

		z=-1*UnityEngine.Random.Range(min,max);
		x=UnityEngine.Random.Range(-z,z);
		return new Vector3(x,y,z);
	}

	
}
