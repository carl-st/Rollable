using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Help : MonoBehaviour {


	public Toggle showOnStart;

	void Start(){
		showOnStart.onValueChanged.AddListener((x) => { 
			SwitchHelp(x);
		});

		if (PlayerPrefs.GetInt ("Help") == 1) {
						showOnStart.isOn = true;
				} else { 
						showOnStart.isOn = false;
				}
		}
	
	void SwitchHelp(bool isToggleOn){
		if (isToggleOn == true) {
			PlayerPrefs.SetInt("Help",1); 
		} else {
			PlayerPrefs.SetInt("Help",0); 
		}
		}

	void OnDisable(){
				Time.timeScale = 1;
		}
}
