using UnityEngine;
using System.Collections;

public class Info : MonoBehaviour {

	public GameObject infoLayer;
	private float originalWidth = 800;  // define here the original resolution
	private float originalHeight = 480; // you used to create the GUI contents 
	private Vector3 scale;
	public GUISkin customSkin;
	private int guiDepth = 1;
	public Texture closeButton;

	void OnGUI(){
		GUI.depth = guiDepth;
		GUI.skin = customSkin;
		scale.x = Screen.width / originalWidth; // calculate hor scale
		scale.y = Screen.height / originalHeight; // calculate vert scale
		scale.z = 1;
		
		var centeredStyle = GUI.skin.GetStyle("Label");
		var svMat = GUI.matrix; // save current matrix
		// substitute matrix - only scale is altered from standard
		GUI.matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity, scale);
		
		if (GUI.Button (new Rect (716, 32, 64, 64), closeButton, centeredStyle)){
			Time.timeScale = 1;
			infoLayer.SetActive(false);	
			Menu.layerActive=false;
		}
		
		
		GUI.matrix = svMat;
	}
}
