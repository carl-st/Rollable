using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float speedAc;
	public static int count;
	private float timer;
	private Vector3 deltaAc;
	private int timerint;
	private int multiplier = 1;
	public GameObject resultsTexture;
	public GameObject pauseTexture;
	public GameObject pauseUI, resultsUI, helpUI;
	private bool isPaused;
	public AudioClip pointSound, accelerationSound, timebonusSound;

	//GUI

	public Text pointsText, timeText, multiplierText;
	public Button pauseButton;

	//accelerometer
	private static Vector3 zeroAc;
	private static Vector3 curAc;
	private float sensH = 15; //13
	private float sensV = 15; //13
	private float smooth = 0.0f;
	private float GetAxisH = 0;
	private float GetAxisV = 0;


	void Start() {
		count = 0;
		timer = 61;
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		ResetAxes();

		//Trail
		Color nColor = new Color(Random.value, Random.value, Random.value, Random.value);
				
		// Get the material list of the trail as per the scripting API.
		Material trail = GetComponent<TrailRenderer>().material;
		
		// Set the color of the material to tint the trail.
		trail.SetColor("_Color", nColor);
		GetComponent<Light>().color = nColor;

		GetComponent<MeshRenderer>().material.SetColor("_Color",nColor);


		if (PlayerPrefs.GetInt("Help") == 1) {
			helpUI.SetActive(true);
			Time.timeScale = 0;
			}
			

		pauseButton.onClick.AddListener (() => {
						Time.timeScale = 0;
						pauseTexture.SetActive (true);
						pauseUI.SetActive (true); });

		}

	void Update() { //Before rendering a frame
				timer -= Time.deltaTime;
				timerint = (int)timer;
				timeText.text = timerint.ToString ();

				if (timer <= 0) {
					resultsUI.SetActive(true);	
					resultsTexture.SetActive (true);
				}

				if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.WP8Player) { 
						if (Input.GetKey (KeyCode.Escape)) {
							Time.timeScale = 0;
							pauseUI.SetActive (true);
						}
				}
		}


	void FixedUpdate() { //Called before physics calculations

		if (SystemInfo.deviceType == DeviceType.Desktop) {
						float vertical = Input.GetAxis ("Vertical");
						float horizontal = Input.GetAxis ("Horizontal");

						Vector3 movement = new Vector3 (horizontal, 0.0f, vertical);

						GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);
				} else {
			curAc = Vector3.Lerp(curAc, Input.acceleration-zeroAc, Time.deltaTime/smooth);
			GetAxisV = Mathf.Clamp(curAc.y * sensV, -1, 1);
			GetAxisH = Mathf.Clamp(curAc.x * sensH, -1, 1);
			 
			// now use GetAxisV and GetAxisH instead of Input.GetAxis vertical and horizontal
			// If the horizontal and vertical directions are swapped, swap curAc.y and curAc.x
			// in the above equations. If some axis is going in the wrong direction, invert the
			// signal (use -curAc.x or -curAc.y)
			
			Vector3 movement = new Vector3 (GetAxisH, 0.0f, GetAxisV);
			deltaAc = movement - deltaAc; //????????
			GetComponent<Rigidbody>().AddForce(movement * speedAc);

				}

	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.tag == "Point") {

			Color newcolor = other.gameObject.GetComponent<PointProps>().pointColor;
			if(newcolor == GetComponent<TrailRenderer>().material.GetColor("_Color")){
				multiplier++;
				//multiplierText.text = "x" + multiplier.ToString(); //multiplier
				multiplierText.text = "x" + multiplier.ToString();
			} else {
				GetComponent<TrailRenderer>().material.SetColor("_Color",newcolor);
				GetComponent<Light>().color=newcolor;
				GetComponent<MeshRenderer>().material.SetColor("_Color",newcolor);
				multiplier=1;
				multiplierText.text = "x1";
			}

			PlaySound(pointSound);
			other.gameObject.SetActive(false);
						count = count + 1*multiplier;
			pointsText.text = "Points: "+count.ToString();
				}
		if (other.gameObject.tag == "Finish") {
			resultsTexture.SetActive (true);
		}
		if (other.gameObject.tag == "Accelerator") {
			PlaySound(accelerationSound);
			GetComponent<Rigidbody>().AddForce (2000*GetComponent<Rigidbody>().velocity.normalized);
		}
		if (other.gameObject.tag == "BumpingAccelerator") {
			PlaySound(accelerationSound);
			GetComponent<Rigidbody>().AddForce (-5000*GetComponent<Rigidbody>().velocity.normalized);
		}
		if (other.gameObject.tag == "TimeBonus") {
			PlaySound(timebonusSound);
			timer+=5;
			other.gameObject.SetActive(false);
		}
	}

	public static void ResetAxes(){
		zeroAc = Input.acceleration;
		curAc = Vector3.zero;
	}

	private void PlaySound(AudioClip soundClip){
		if(PlayerPrefs.GetInt("Sound")==1)
		{
			GetComponent<AudioSource>().clip=soundClip;
			GetComponent<AudioSource>().Play();
		}
	}
}
