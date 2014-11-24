using UnityEngine;
using System.Collections;

public class merge2d : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collision) {
		if (gameObject.tag == "Droplet" && collision.gameObject.tag == "Droplet"){
			Debug.Log (collision.collider);
			dropletController script = GameObject.Find("Player Droplets").GetComponent("dropletController") as dropletController;
			script.setCollide(true, collision.transform.position);
			Destroy (gameObject);
			Destroy (collision.gameObject);
		}
	}
}
