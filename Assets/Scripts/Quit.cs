using UnityEngine;
using System.Collections;


public class Quit : MonoBehaviour {


	public GameObject pauseLayer,levels, texts;
	

	void Update () {
				if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.WP8Player) {
//			if (Input.GetKey (KeyCode.Escape) && lvlChoosing == false) {
//					Application.Quit();
//			} 
						if (Input.GetKey (KeyCode.Escape)) {
								StartCoroutine ("AnimateBack");

						}
				}

				if (!Menu.layerActive) {
						for (var i = 0; i < Input.touches.Length; i++) {
								Touch touch = Input.touches [i];
								Ray ray = Camera.main.ScreenPointToRay (touch.position);
								RaycastHit hit = new RaycastHit ();
			
								if (Physics.Raycast (ray, out hit, 1000)) {
										if (hit.collider.gameObject == this.gameObject) {

												if (this.gameObject.tag == "Start") {
//							this.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 3);
//							pauseLayer.SetActive(true);
//							Application.LoadLevel(1);
//							guiDepth=0;
						        
														//float smoothing = 0.1f;        // The speed with which the camera will be following.
														//mainCamera.transform.rotation = Quaternion.Slerp(mainCamera.transform.rotation,Quaternion.Euler(-90,270,0),smoothing*Time.time);
														StopCoroutine ("AnimateBack");

														StartCoroutine ("Animate");
												}

												if (this.gameObject.tag == "Back") {
														StopCoroutine ("Animate");
														StartCoroutine ("AnimateBack");
												}

												if (this.gameObject.tag == "SquareLevel") {
														this.gameObject.transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z - 3);
														pauseLayer.SetActive (true);
														Application.LoadLevel (1);
												}

												if (this.gameObject.tag == "TriangleLevel") {
														this.gameObject.transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z - 3);
														pauseLayer.SetActive (true);
														Application.LoadLevel (2);
												}
												if (this.gameObject.tag == "CircleLevel") {
														this.gameObject.transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z - 3);							
														pauseLayer.SetActive (true);
														Application.LoadLevel (3);
												}
												
										}
								}
			
						}
				}
		}

	IEnumerator Animate(){
		while (levels.transform.position.z >16.9f) {
						levels.transform.position -= new Vector3 (0, 0, Time.deltaTime*10);
						texts.transform.position -= new Vector3 (0, 0, Time.deltaTime*10);
						yield return null;
				}
		}

	IEnumerator AnimateBack(){
		while (texts.transform.position.z <26.5166f) {
			levels.transform.position += new Vector3 (0, 0, Time.deltaTime*10);
			texts.transform.position += new Vector3 (0, 0, Time.deltaTime*10);
			yield return null;
		}
	}
	

}
