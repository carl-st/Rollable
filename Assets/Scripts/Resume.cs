using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Resume : MonoBehaviour {
	public GameObject pauseTexture, pauseUI;
	public Button ResumeButton, RestartButton, QuitButton;
	// Use this for initialization
	void Start () {
		PlayerController.ResetAxes();

		ResumeButton.onClick.AddListener (() => {
						PlayerController.ResetAxes ();
						Time.timeScale = 1;
						pauseTexture.SetActive (false);
						pauseUI.SetActive (false); });
		RestartButton.onClick.AddListener (() => {
						Time.timeScale = 1;
						Application.LoadLevel (Application.loadedLevel);
						pauseUI.SetActive (false);});
		QuitButton.onClick.AddListener (() => {
						Time.timeScale = 1;
						Application.LoadLevel (0);});
	}
	
	// Update is called once per frame
	void Update () {

	}



}
