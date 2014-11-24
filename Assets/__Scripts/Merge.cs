using UnityEngine;
using System.Collections;

public class Merge : MonoBehaviour {
	GameObject playerMerge;
	GameObject player1;
	GameObject player2;

	// Use this for initialization
	void Start () {
		playerMerge = GameObject.Find ("Droplet_merge");
		playerMerge.renderer.enabled = false;
		player1 = GameObject.Find ("Droplet1");
		player2 = GameObject.Find ("Droplet2");
	
	}
	
	// Update is called once per frame
	void Update () {
		player1.transform.position += new Vector3 (.03f, 0, 0);
		player2.transform.position -= new Vector3 (.03f, 0, 0);

	}

	void OnCollisionEnter(Collision collision) {
//		Destroy(other.gameObject);
		Debug.Log (collision.collider);
		playerMerge.renderer.enabled = true;
		player1.renderer.enabled = false;
		player2.renderer.enabled = false;
	}
	void OnCollisionStay(Collision collision) {
		playerMerge.transform.position += new Vector3 (.02f, -0.02f, 0);
	}
}
