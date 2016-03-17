using UnityEngine;
using UnityEngine.UI;
using System.Collections;
#if UNITY_IPHONE
using UnityEngine.SocialPlatforms;
#endif

public class Results : MonoBehaviour {

	public Text ScoreText;
	public GameObject gameUI;

	// Use this for initialization
	

	void Start () {
		gameUI.SetActive (false);
		Time.timeScale = 0;
		if(!PlayerPrefs.HasKey("HighScore"+Application.loadedLevel))
		   	{
			PlayerPrefs.SetInt("HighScore"+Application.loadedLevel,PlayerController.count);
			#if UNITY_IPHONE
			ReportScore(true, Application.loadedLevel);
			#endif
			}
		if (PlayerController.count > PlayerPrefs.GetInt ("HighScore" + Application.loadedLevel)) {
						PlayerPrefs.SetInt ("HighScore" + Application.loadedLevel, PlayerController.count);			
						ScoreText.text = "New highscore!";
						#if UNITY_IPHONE
						ReportScore (true, Application.loadedLevel);
						#endif
				} else { 
			ScoreText.text = "Score: " + PlayerController.count;
				}

						int tmp = PlayerPrefs.GetInt ("TotalScore");
						tmp += PlayerController.count;
						PlayerPrefs.SetInt ("TotalScore", tmp);
						#if UNITY_IPHONE
						ReportScore(true, 4);
						#endif


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
	//These next two methods show the leaderboard
	
	void DoLeaderboard () {
		#if UNITY_IPHONE
		Social.localUser.Authenticate (ProcessAuthentication);
		#endif
	}
	
	void ProcessAuthentication (bool success) {
		#if UNITY_IPHONE
		if (success) {
			Debug.Log ("Authentication successful");
			Social.CreateLeaderboard();
			Social.CreateLeaderboard().id = "com.carlst.rollable.leaderboard";
			Social.ShowLeaderboardUI();
		}
		else
			Debug.Log ("Failed to authenticate");
		#endif
	}
	
	
	//these next two methods report a score to the leaderboard
	
//	void reportScoreToBoard() {
//		#if UNITY_IPHONE
//		Social.localUser.Authenticate (ReportScore);
//		#endif
//	}
	
	
	void ReportScore (bool success, int map) {
		#if UNITY_IPHONE
		if (success) {
			
			Debug.Log ("Authentication successful");
			
			Social.CreateLeaderboard();

			switch (map){
			case 1: 
				Social.CreateLeaderboard().id = "com.carlst.rollable.leaderboard.square";
				Social.ReportScore(PlayerPrefs.GetInt("HighScore1"),"com.carlst.rollable.leaderboard.square",  successed => {
					Debug.Log(successed ? "Reported score successfully" : "Failed to report score");}); 
				break;
			case 2: Social.CreateLeaderboard().id = "com.carlst.rollable.leaderboard.triangle";
				Social.ReportScore(PlayerPrefs.GetInt("HighScore2"),"com.carlst.rollable.leaderboard.triangle",  successed => {
					Debug.Log(successed ? "Reported score successfully" : "Failed to report score");});
				break;
			case 3: Social.CreateLeaderboard().id = "com.carlst.rollable.leaderboard.circle";
				Social.ReportScore(PlayerPrefs.GetInt("HighScore3"),"com.carlst.rollable.leaderboard.circle",  successed => {
					Debug.Log(successed ? "Reported score successfully" : "Failed to report score");});
				break;
			case 4: Social.CreateLeaderboard().id = "com.carlst.rollable.leaderboard.total";
				Social.ReportScore(PlayerPrefs.GetInt("TotalScore"),"com.carlst.rollable.leaderboard.total",  successed => {
					Debug.Log(successed ? "Reported score successfully" : "Failed to report score");});
				break;
			}
//
//			Social.CreateLeaderboard().id = "com.carlst.rollable.leaderboard.square";
//			Social.ReportScore(PlayerPrefs.GetInt("timeElapsed"),"com.carlst.rollable.leaderboard.square",  successed => {
//				Debug.Log(successed ? "Reported score successfully" : "Failed to report score");});
			
			//if you want uncomment below to show leaderboard!  
			//Social.ShowLeaderboardUI();
		}
		else
			Debug.Log ("Failed to authenticate");
		
		#endif
	}

}
