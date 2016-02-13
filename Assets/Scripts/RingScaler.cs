using UnityEngine;
using System.Collections;

public class RingScaler : MonoBehaviour {
	
	public static bool entered;
	bool thisEntered = false;

	string ringType;

	void FixedUpdate(){

		if (!GameScript.alive)
			return;

		if (GetComponent<RingMetaData> ().startBig) {
			if (tag == "red") {
				transform.localScale = transform.localScale * 0.975f;
			} else if (tag == "blue") {
				transform.localScale = transform.localScale * 0.965f;
			} else if (tag == "green") {
				transform.localScale = transform.localScale * 0.955f;
			}
		} 
		else {
			if (tag == "red") {
				transform.localScale = transform.localScale * 1.020f;
			} else if (tag == "blue") {
				transform.localScale = transform.localScale * 1.030f;
			} else if (tag == "green") {
				transform.localScale = transform.localScale * 1.040f;
			}
		}

	}

	void Update () {

		if(GameScript.alive && (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown(0))){
			if(thisEntered){
				if(tag == "red"){
					GameScript.score++;
				} else if (tag == "blue") {
					GameScript.score += 2;
				} else if (tag == "green"){
					GameScript.score += 3;
				}
					
				StartCoroutine(Waiter());
			} else if(!entered) {
				GameScript.alive = false;
			}
		}

		if (!GameScript.alive) {
			entered = false;
		}
	}

	IEnumerator Waiter(){
		yield return new WaitForSeconds(.05f);
		entered = false;
		gameObject.SetActive(false);
	}

	void OnTriggerEnter2D(Collider2D coll){
		entered = true;
		thisEntered = true;
	}

	void OnTriggerExit2D(Collider2D coll){
		GameScript.alive = false;
	}
}
