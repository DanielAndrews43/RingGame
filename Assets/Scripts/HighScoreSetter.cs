using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScoreSetter : MonoBehaviour {

	public Text text;

	// Use this for initialization
	void Start () {
		text.text = "High Score: " + PlayerPrefs.GetInt ("HighScore", 0).ToString();
	}
}
