using UnityEngine;
using System.Collections;

public class titleMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.Find("dropletTitle").renderer.enabled = true;
		GameObject.Find("chapterScreen").renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad > 3f) {
			GameObject.Find("dropletTitle").renderer.enabled = false;
			GameObject.Find("chapterScreen").renderer.enabled = true;
			if (Input.GetKey(KeyCode.Space)) {
				Application.LoadLevel("Prologue");
			}
		}
	
	}
}
