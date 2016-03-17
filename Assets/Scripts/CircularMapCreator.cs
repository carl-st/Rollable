using UnityEngine;
using System.Collections;

public class CircularMapCreator : MonoBehaviour {
	public GameObject point, point2, point3, point4, accelerator,timebonus;
	public int objectsNumber;
	public int min, max, radiusX, radiusZ;
	public float time;
	private int k, currentPoint;
	private float passedTime, pointsSize;
	private GameObject[] gameObjects, points;
	
	void Start(){
		points = new GameObject[] {point,point2,point3,point4};
		pointsSize = 0.6f;
		gameObjects = new GameObject[objectsNumber];
		for (int k=0; k<objectsNumber; k++) {
			GeneratePoints(k,false);
				}
//		for (int j=0; j<2; j++) {
//						Instantiate (accelerator, GeneratedPosition (2.346896f), Quaternion.identity);
//						Instantiate (timebonus, GeneratedPosition (0.6855319f), Quaternion.identity);
//				}
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
				if(currentPoint>=(objectsNumber-1)) currentPoint=0;
			}
			
			else { 
				
				Component halo = gameObjects [currentPoint].GetComponent ("Halo");
				halo.GetType ().GetProperty ("enabled").SetValue (halo, true, null);
				
			}
			
		}
//		
		if (passedTime >= time) {
			passedTime = 0;
			//gameObjects =  GameObject.FindGameObjectsWithTag ("Point");
			currentPoint++;
			if(currentPoint>=(objectsNumber-1)){
				Destroy(gameObjects[currentPoint]);
				GeneratePoints (currentPoint,true);
				//currentPoint=0;
			}
			
			if(gameObjects[currentPoint]!=null)
			{
				Destroy(gameObjects[currentPoint]);
				gameObjects[currentPoint]=null;
			}

			GeneratePoints(currentPoint,true);

		}
	}

	Vector3 GeneratedPosition(float y){
		int x,z;
		Random.seed=(int)System.DateTime.Now.Ticks;
		x=UnityEngine.Random.Range(min,max);
		z=UnityEngine.Random.Range(min,max);
		
		return new Vector3(x,y,z);
	}


	void GeneratePoints(int Point, bool small){
//		float i = (currentPoint * 1.0f) / objectsNumber;
		
		// get the angle for this step (in radians, not degrees)
		float angle = Random.Range (0,2*Mathf.PI);  //losowy kat
		// the X &amp; Y position for this angle are calculated using Sin &amp; Cos
		float x = Mathf.Sin(angle) * Random.Range(37,62);
		float z = Mathf.Cos(angle) * Random.Range(37,62); //losowy radius TO
		
		Vector3 pos = new Vector3(x, 0, z);
		gameObjects [Point]=(GameObject)Instantiate (points[Random.Range(0,4)], pos, Quaternion.identity);
		if (small == true) {
						gameObjects [Point].transform.localScale = new Vector3 (0, 0, 0);
						pointsSize = 0;
				}
	}



}
