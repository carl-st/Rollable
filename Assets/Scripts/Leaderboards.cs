using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Leaderboards : MonoBehaviour {

	public Text Square, Triangle, Circle;

	void Start(){
		Square.text = " Square: "+PlayerPrefs.GetInt("HighScore1");
		Triangle.text = "Triangle: "+PlayerPrefs.GetInt("HighScore2");
		Circle.text = "Circle: "+PlayerPrefs.GetInt("HighScore3");

	}


}
