using UnityEngine;
using System.Collections;

public class BallRotating : MonoBehaviour {
	public int speed;
	public int lengthOfLineRenderer = 20;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(0,0,7+Mathf.Sin(Time.time));
		transform.Rotate (new Vector3 (-speed, 0, 0) * Time.deltaTime);
		LineRenderer lineRenderer = GetComponent<LineRenderer>();
		int i = 0;
		while (i < lengthOfLineRenderer) {
			Vector3 pos = new Vector3(0, 0, 25+Mathf.Sin(i+Time.time*5));
			lineRenderer.SetPosition(1, pos);
			i++;

		}
	}
}
