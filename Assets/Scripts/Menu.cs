using UnityEngine;
using UnityEngine.UI;
using System.Collections;
#if UNITY_IPHONE
using UnityEngine.SocialPlatforms;
#endif

public class Menu : MonoBehaviour {

	public Texture twitterLogo;
	//public Texture soundLogo, nosoundLogo, helpButton, infoButton, leaderButton, gamecenterButton;
	public GameObject mainCamera;
	public static bool layerActive = false;
	public Button GCButton, SButton, TwitterButton, Lvl1, Lvl2, Lvl3;
	public Sprite soundSprite, nosoundSprite, lvl2Unlocked, lvl3Unlocked;
	public Text pointsText;

//	private Animator _animator;
//	private CanvasGroup _canvasGroup;
//	public bool IsOpen { 
//		get { return _animator.GetBool("IsOpen");}
//		set { _animator.SetBool("IsOpen", value);}
//	}

	void Start(){
		if (!PlayerPrefs.HasKey ("Sound")) {
			PlayerPrefs.SetInt ("Sound", 1);

		}

		if (PlayerPrefs.GetInt ("Sound") == 1) {
						GetComponent<AudioSource>().Play ();
			SButton.image.sprite=soundSprite;
		} else { 
			SButton.image.sprite=nosoundSprite;
		}
			if (!PlayerPrefs.HasKey ("TotalScore")) {
				PlayerPrefs.SetInt ("TotalScore", 0);
			}
			
			if(!PlayerPrefs.HasKey("HighScore"))
			{
				PlayerPrefs.SetInt("HighScore",0);
			}		
			
			if (!PlayerPrefs.HasKey ("Help")) {
				PlayerPrefs.SetInt ("Help", 1);
			}
		//!!!!!!	
		pointsText.text="Collected points: " + PlayerPrefs.GetInt ("TotalScore").ToString();
		
		if (PlayerPrefs.GetInt ("TotalScore") >= 500) {
			Lvl2.image.sprite = lvl2Unlocked;
			Lvl2.onClick.AddListener (() => {
				Application.LoadLevel(2);});
		}
		
		if (PlayerPrefs.GetInt ("TotalScore") >= 2000) {
			Lvl3.image.sprite = lvl3Unlocked;
			Lvl3.onClick.AddListener (() => {
				Application.LoadLevel(3);});
		}

		//GAMECENTER
		Social.localUser.Authenticate (success => {
			if (success) {
				Debug.Log ("Authentication successful");
				string userInfo = "Username: " + Social.localUser.userName + 
					"\nUser ID: " + Social.localUser.id + 
						"\nIsUnderage: " + Social.localUser.underage;
				Debug.Log (userInfo);
			}
			else
				Debug.Log ("Authentication failed");
		});

//		GCButton.onClick.AddListener (() => {
//						DoLeaderboard (); });

		SButton.onClick.AddListener (() => {
			SwitchSound (); });

		TwitterButton.onClick.AddListener (() => {
			GotoTwitter(); });

		Lvl1.onClick.AddListener (() => {
			Application.LoadLevel(1);});
	}

	void Update() {
				if (Application.platform == RuntimePlatform.Android) {
						if (Input.GetKey (KeyCode.Escape)) {
								Application.Quit ();
				
								return;
						}

				}
		}
		
		void DoLeaderboard () {
			//		#if UNITY_IPHONE
			//		Social.localUser.Authenticate (ProcessAuthentication);
//		#else
//		leaderLayer.SetActive(true);
//		layerActive = true;
//		#endif
//		leaderLayer.SetActive(true);
//		layerActive = true;
	}


	//ROZKMINIC!!!
//	public void Awake(){
//		_animator = GetComponent<Animator>();
//		_canvasGroup = GetComponent<CanvasGroup>();
//		
//		var rect = GetComponent<RectTransform>();
//		rect.offsetMax = rect.offsetMin = new Vector2 (0, 0);
//		
//	}
//	
//	public void Update(){
//		if (_animator.GetCurrentAnimatorStateInfo (0).IsName ("Open")) {
//			_canvasGroup.blocksRaycasts = _canvasGroup.interactable = false;
//		} else {
//			_canvasGroup.blocksRaycasts = _canvasGroup.interactable = true;
//		}
//	}

	void GotoTwitter(){
				const string TWITTER_ADDRESS = "https://twitter.com/carlst3";
				Application.OpenURL (TWITTER_ADDRESS);
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

	public void SwitchSound(){
		if (PlayerPrefs.GetInt ("Sound") == 0) {
			PlayerPrefs.SetInt ("Sound", 1);
			GetComponent<AudioSource>().Play ();
			SButton.image.sprite=soundSprite;
		} else {
			PlayerPrefs.SetInt ("Sound", 0);
			GetComponent<AudioSource>().Stop ();
			SButton.image.sprite=nosoundSprite;
		}

	}
}
