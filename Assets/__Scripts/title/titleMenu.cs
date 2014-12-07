using UnityEngine;
using System.Collections;

public class titleMenu : MonoBehaviour {
	public GameObject dropletTitle;
	public GameObject chapterScreen;
	public GameObject[] chooseCharacter;

	// Use this for initialization
	void Start () {
		dropletTitle.renderer.enabled = true;
		chapterScreen.renderer.enabled = false;
		foreach (GameObject child in chooseCharacter) {
			child.renderer.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			if(dropletTitle != null) {
				Destroy(dropletTitle);
				chapterScreen.renderer.enabled = true;
			} else if(chapterScreen != null) {
				Destroy(chapterScreen);
				foreach (GameObject child in chooseCharacter) {
					child.renderer.enabled = true;
				}
			} else {
				Application.LoadLevel("Prologue");
			}
		}
	
	}
}
