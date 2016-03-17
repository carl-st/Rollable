using UnityEngine;
using System.Collections;

public class Textmovement : MonoBehaviour {
	private float passedtime;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//passedtime += 3*Time.deltaTime;
		transform.Rotate (new Vector3 (-1, 0, 0) * (Mathf.Sin(Time.time*3)));
	}
}
