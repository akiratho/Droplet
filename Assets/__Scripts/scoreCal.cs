using UnityEngine;
using System.Collections;

public class scoreCal : MonoBehaviour {
	float player1;
	float player2;
	float player3;
	float player4;

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetFloat("player1", 0);
		PlayerPrefs.SetFloat("player2", 0);
		PlayerPrefs.SetFloat("player3", 0);
		PlayerPrefs.SetFloat("player4", 0);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void addScore(string player, float addScore){
		if (player.IndexOf("0") > 0) {
			player1 = PlayerPrefs.GetFloat("player1", 0);
			PlayerPrefs.SetFloat("player1", player1 + addScore);
		}
		if (player.IndexOf("1") > 0) {
			player2 = PlayerPrefs.GetFloat("player2", 0);
			PlayerPrefs.SetFloat("player2", player2 + addScore);
		}
		if (player.IndexOf("2") > 0) {
			player3 = PlayerPrefs.GetFloat("player3", 0);
			PlayerPrefs.SetFloat("player3", player3 + addScore);
		}
		if (player.IndexOf("3") > 0) {
			player4 = PlayerPrefs.GetFloat("player4", 0);
			PlayerPrefs.SetFloat("player4", player4 + addScore);
		}
	}

	void OnGUI(){
//		GUILayout.Label ("player1: " + player1);
//		GUILayout.Label ("player2: " + player2);
//		GUILayout.Label ("player3: " + player3);
//		GUILayout.Label ("player4: " + player4);
	}
}
