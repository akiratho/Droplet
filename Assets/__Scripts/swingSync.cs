using UnityEngine;
using System.Collections;
using GamepadInput;

public class swingSync : MonoBehaviour {
	bool isControllerConnected = false;
	public float player1Move;
	public float player2Move;
	public float player3Move;
	public float player4Move;
	
	public Texture2D[] playerState;
	int i;
	int player1State;
	int player2State;
	int player3State;
	int player4State;
	
	int findState(float move) {
		if (move < -0.5f) {
			return 0;
		} else if (move >= -0.5f && player1Move < 0f) {
			return 1;
		}else if (move == 0f) {
			return 2;
		}else if (move <= 0.5f && player1Move > 0f) {
			return 3;
		}else if (move > 0.5f) {
			return 4;
		} else {
			return -1;
			Debug.Log ("move error");
		}
	}
	
	// Use this for initialization
	void Start () {
		switch (Input.GetJoystickNames().Length) {
		case 0:
			Debug.Log("Please plug in your controllers");
			break;
		case 1:
			Debug.Log("Please plug in 2 controllers");
			break;
		case 2:
			isControllerConnected = true;
			break;
		}
		GameObject.Find("swing_wood_front").renderer.enabled = false;
		GameObject.Find("swing_wood_back").renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isControllerConnected){
			player1Move = GamePad.GetState(GamePad.Index.One).LeftStickAxis.x;
			player2Move = GamePad.GetState(GamePad.Index.One).rightStickAxis.x;
			player3Move = GamePad.GetState(GamePad.Index.Two).LeftStickAxis.x;
			player4Move = GamePad.GetState(GamePad.Index.Two).rightStickAxis.x;
		}
		if (player1Move < 0 && player2Move < 0 && player3Move < 0 && player4Move < 0) {
			GameObject.Find("swing_wood_front").renderer.enabled = true;
			GameObject.Find("swing_wood_back").renderer.enabled = false;
			GameObject.Find("swing_wood").renderer.enabled = false;
		}
		if (player1Move == 0 && player2Move == 0 && player3Move == 0 && player4Move == 0) {
			GameObject.Find("swing_wood").renderer.enabled = true;
			GameObject.Find("swing_wood_front").renderer.enabled = false;
			GameObject.Find("swing_wood_back").renderer.enabled = false;
		}
		if (player1Move > 0 && player2Move > 0 && player3Move > 0 && player4Move > 0) {
			GameObject.Find("swing_wood_back").renderer.enabled = true;
			GameObject.Find("swing_wood").renderer.enabled = false;
			GameObject.Find("swing_wood_front").renderer.enabled = false;
		}
		
		player1State = findState(player1Move);
		player2State = findState(player2Move);
		player3State = findState(player3Move);
		player4State = findState(player4Move);
		
	}
	
	void OnGUI(){
//		GUILayout.Label("Player1: " + player1Move);
//		GUILayout.Label("Player2: " + player2Move);
//		GUILayout.Label("Player3: " + player3Move);
//		GUILayout.Label("Player4: " + player4Move);
//		GUILayout.Label(playerState[player1State], GUILayout.Width(100));
//		GUILayout.Label(playerState[player2State], GUILayout.Width(100));
//		GUILayout.Label(playerState[player3State], GUILayout.Width(100));
//		GUILayout.Label(playerState[player4State], GUILayout.Width(100));
		GUI.Label(new Rect(10, 10, 100, 20), "Player1: " + player1Move);
		GUI.Label(new Rect(Screen.width/4 + 10, 10, 100, 20), "Player2: " + player2Move);
		GUI.Label(new Rect(Screen.width/2 + 10, 10, 100, 20), "Player3: " + player3Move);
		GUI.Label(new Rect(Screen.width - 150, 10, 100, 20), "Player4: " + player4Move);
		GUI.DrawTexture(new Rect(10, 50, 100, 50), playerState[player1State], ScaleMode.ScaleToFit, true, 0f);
		GUI.DrawTexture(new Rect(Screen.width/4 + 10, 50, 100, 50), playerState[player2State], ScaleMode.ScaleToFit, true, 0f);
		GUI.DrawTexture(new Rect(Screen.width/2 + 10, 50, 100, 50), playerState[player3State], ScaleMode.ScaleToFit, true, 0f);
		GUI.DrawTexture(new Rect(Screen.width - 150, 50, 100, 50), playerState[player4State], ScaleMode.ScaleToFit, true, 0f);
	}
}