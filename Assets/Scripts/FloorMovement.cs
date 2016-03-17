using UnityEngine;
using System.Collections;

public class FloorMovement : MonoBehaviour {

	private float n;
	public int distance;
	public int start;
	public int speed;
	// Update is called once per frame
	void Start () {
		transform.position = new Vector3(transform.position.x, transform.position.y, start);
		}


	void Update () {

		n += speed*Time.deltaTime;
		if(n >= distance){ n=0;}
		transform.position = new Vector3(transform.position.x, transform.position.y, n+start);

	}
}
