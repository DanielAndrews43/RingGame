using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameScript : MonoBehaviour {


	public Text scoreText;
	public Text gameOverText;
	public Button playAgainButton;
	public Button menuButton;

	public static int score = 0;
	public static bool alive = true;

	public Transform[] rings;
	public GameObject center;

	public float insideChance;
	
	float velocity2 = 0f;

	bool died = true;

	void Start(){
		alive = true;
		score = 0;
		InvokeRepeating("SpawnRing", 1f, .8f);
	}

	// Update is called once per frame
	void Update () {
		scoreText.text = score.ToString();

		if (!alive) {

			if(died){
				PlayerPrefs.SetInt ("deaths", PlayerPrefs.GetInt ("deaths",0)+1);
				died = false;
			}

			CancelInvoke ();

			if(score > PlayerPrefs.GetInt("HighScore", 0)){
				PlayerPrefs.SetInt("HighScore", score);
			}

			float alpha = Mathf.SmoothDamp (0, 255, ref velocity2, 1.8f);
			gameOverText.color = new Color (0, 0, 0, alpha);
			if(center.GetComponent<Rigidbody2D>() == null)
				center.AddComponent(typeof(Rigidbody2D));
			StartCoroutine(buttons());
		}
	}

	IEnumerator buttons(){
		yield return new WaitForSeconds(1.2f);
		playAgainButton.gameObject.SetActive (true);
		menuButton.gameObject.SetActive (true);
	}

	void SpawnRing(){
		int random = (int)Random.Range (0, rings.Length);

		Transform ring = (Transform) Instantiate (rings[random], Vector3.zero, Quaternion.identity);

		if (Random.value > insideChance) {
			ring.GetComponent<RingMetaData> ().startBig = true;
		} 
		else {
			ring.GetComponent<RingMetaData> ().startBig = false;
			ring.localScale = new Vector3 (0.05f, 0.05f);
		}
	}
}
