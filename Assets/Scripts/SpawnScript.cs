using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	public GameObject[] rings;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnRing", 1f, 2f);
	}

	void SpawnRing(){
		var ring = rings [Random.Range (0, rings.Length)];
		Transform trans = ring.GetComponent<Transform> ();
		trans.localScale = new Vector3 (1,1,1)* Random.value;
		Instantiate (ring, transform.position, Quaternion.identity);
	}
}
