using UnityEngine;
using System.Collections;

public class mainMenu : MonoBehaviour {
	
	void Start(){

	}

	// Update is called once per frame
	void Update () {
	
	}

	public void displayScore () {



	}

	
	public void OnClickPlay(){
		Application.LoadLevel (0);
	}
	public void OnClickAchievement(){
		
		Application.LoadLevel (2);
	}
	public void OnClickMenu(){
		
		Application.LoadLevel (1);
	}
	public void OnClickReset(){
		PlayerPrefs.DeleteAll ();
	}
}
