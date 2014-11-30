using UnityEngine;
using System.Collections;
using GamepadInput;

public class dropletController : MonoBehaviour {
	public GameObject droplet;
	public string tagDroplet = "Droplet";

	public KeyCode player1Left = KeyCode.A;
	public KeyCode player1Right = KeyCode.D;
	public KeyCode player2Left = KeyCode.J;
	public KeyCode player2Right = KeyCode.L;
	public KeyCode player3Left = KeyCode.LeftArrow;
	public KeyCode player3Right = KeyCode.RightArrow;
	public KeyCode player4Left = KeyCode.Keypad4;
	public KeyCode player4Right = KeyCode.Keypad6;
	
	bool isControllerConnected = false;
	public float player1Move;
	public float player2Move;
	public float player3Move;
	public float player4Move;
	public float playerMoveSpeed = 0.01f;

	public Vector3 player1Pos = new Vector3 (-7f, 0, 0);
	public Vector3 player2Pos = new Vector3 (-3f, 0, 0);
	public Vector3 player3Pos = new Vector3 (4f, 0, 0);
	public Vector3 player4Pos = new Vector3 (7f, 0, 0);

	public Vector3[] playerSize;
	public Vector3 initialPlayerSize = new Vector3 (.8f, .8f, 0);

	public float merge2Size = .6f;
	public float merge3Size = .55f;
	public float merge4Size = .55f;

	public Vector3 speedVector = new Vector3 (.03f, 0, 0);
	public Vector3 disDifference = new Vector3(1f, 0, 0);

	//initialization
	public void initiateDroplet (string name, Vector3 position, Vector3 scale){
		GameObject player = Instantiate(droplet, position, Quaternion.identity) as GameObject;
		player.tag = tagDroplet;
		player.name = name;
		player.transform.localScale = scale;
	}

	KeyCode leftKey(int dropletIndex) {
		switch (dropletIndex) {
		case 1:
			return player1Left;
			break;
		case 2:
			return player2Left;
			break;
		case 3:
			return player3Left;
			break;
		case 4:
			return player4Left;
			break;
		}
		return KeyCode.Escape;
	}

	KeyCode rightKey(int dropletIndex) {
		switch (dropletIndex) {
		case 1:
			return player1Right;
			break;
		case 2:
			return player2Right;
			break;
		case 3:
			return player3Right;
			break;
		case 4:
			return player4Right;
			break;
		}
		return KeyCode.Escape;
	}

	float playerMove(int dropletIndex){
		switch (dropletIndex) {
		case 1:
			return player1Move;
			break;
		case 2:
			return player2Move;
			break;
		case 3:
			return player3Move;
			break;
		case 4:
			return player4Move;
			break;
		}
		return -1;
	}

	//control of 1 player
	void manipulate1Player (GameObject droplet, int player){
		//control by keyboard
		if (Input.GetKey(leftKey(player))){
			droplet.transform.position -= speedVector;
		}
		if (Input.GetKey(rightKey(player))){
			droplet.transform.position += speedVector;
		}
		//control by controller
		if (isControllerConnected) {
			droplet.transform.position += new Vector3(playerMove(player) * playerMoveSpeed, 0, 0);
		}
	}
	
	//control of 2 players
	void manipulate2Players(GameObject droplet, int firstPlayer, int secondPlayer) {
		//control by keyboard
		KeyCode firstPlayerLeft = leftKey(firstPlayer);
		KeyCode firstPlayerRight = rightKey(firstPlayer);
		KeyCode secondPlayerLeft = leftKey(secondPlayer);
		KeyCode secondPlayerRight = rightKey(secondPlayer);

		if (Input.GetKey(firstPlayerLeft)){
			if (Input.GetKey(secondPlayerLeft)){
				//2 players go left together
				droplet.transform.position -= speedVector;
			}
			if (Input.GetKey(secondPlayerRight)){
				//first player goes left, second player goes right
				initiateDroplet("player" + firstPlayer,
				                droplet.transform.position - disDifference,
				                playerSize[firstPlayer - 1]);
				initiateDroplet("player" + secondPlayer,
				                droplet.transform.position + disDifference,
				                playerSize[secondPlayer - 1]);
				Destroy(droplet);
			}
		}
		if (Input.GetKey(firstPlayerRight)){
			if (Input.GetKey(secondPlayerRight)){
				//2 players go right together
				droplet.transform.position += speedVector;
			}
			if (Input.GetKey(secondPlayerLeft)){
				//first player goes right, second player goes left
				initiateDroplet("player" + firstPlayer,
				                droplet.transform.position + disDifference,
				                playerSize[firstPlayer - 1]);
				initiateDroplet("player" + secondPlayer,
				                droplet.transform.position - disDifference,
				                playerSize[secondPlayer - 1]);
				Destroy(droplet);
			}
		}
		
		//control by controller
		if (isControllerConnected) {
			float firstPlayerMove = playerMove(firstPlayer);
			float secondPlayerMove = playerMove(secondPlayer);

			if ((firstPlayerMove <= 0 && secondPlayerMove <= 0)||(firstPlayerMove >= 0 && secondPlayerMove >= 0)){
				//move together
				float aveMove = (firstPlayerMove + secondPlayerMove) / 2;
				droplet.transform.position += new Vector3(aveMove * playerMoveSpeed, 0, 0);
			}
			else {
				//split up
				if (firstPlayerMove < 0) {
					initiateDroplet("player" + firstPlayer,
					                droplet.transform.position - disDifference,
					                playerSize[firstPlayer - 1]);
					initiateDroplet("player" + secondPlayer,
					                droplet.transform.position + disDifference,
					                playerSize[secondPlayer - 1]);
				} else {
					initiateDroplet("player" + firstPlayer,
					                droplet.transform.position + disDifference,
					                playerSize[firstPlayer - 1]);
					initiateDroplet("player" + secondPlayer,
					                droplet.transform.position - disDifference,
					                playerSize[secondPlayer - 1]);
				}
				Destroy(droplet);
			}
		}
	}

	//control of 3 players
	void manipulate3Players(GameObject droplet, int firstPlayer, int secondPlayer, int thirdPlayer) {
		//control by keyboard
		KeyCode firstPlayerLeft = leftKey(firstPlayer);
		KeyCode firstPlayerRight = rightKey(firstPlayer);
		KeyCode secondPlayerLeft = leftKey(secondPlayer);
		KeyCode secondPlayerRight = rightKey(secondPlayer);
		KeyCode thirdPlayerLeft = leftKey(thirdPlayer);
		KeyCode thirdPlayerRight = rightKey(thirdPlayer);

		if (Input.GetKey(firstPlayerLeft)){
			if (Input.GetKey(secondPlayerLeft)){
				if (Input.GetKey(thirdPlayerLeft)){
					//Go left together
					droplet.transform.position -= speedVector;
				}
				if (Input.GetKey(thirdPlayerRight)){
					//third player goes right alone
					initiateDroplet("player" + firstPlayer + secondPlayer,
					                droplet.transform.position - disDifference,
					                (playerSize[firstPlayer - 1] + playerSize[secondPlayer - 1]) * merge2Size);
					initiateDroplet("player" + thirdPlayer,
					                droplet.transform.position + disDifference,
					                playerSize[thirdPlayer - 1]);
					Destroy(droplet);
				}
			}
			if (Input.GetKey(secondPlayerRight)){
				if (Input.GetKey(thirdPlayerLeft)){
					//second player goes right alone
					initiateDroplet("player" + firstPlayer + thirdPlayer,
					                droplet.transform.position - disDifference,
					                (playerSize[firstPlayer - 1] + playerSize[thirdPlayer - 1]) * merge2Size);
					initiateDroplet("player" + secondPlayer,
					                droplet.transform.position + disDifference,
					                playerSize[secondPlayer - 1]);
					Destroy(droplet);
				}
				if (Input.GetKey(thirdPlayerRight)){
					//first player goes left alone
					initiateDroplet("player" + firstPlayer,
					                droplet.transform.position - disDifference,
					                playerSize[firstPlayer - 1]);
					initiateDroplet("player" + secondPlayer + thirdPlayer,
					                droplet.transform.position + disDifference,
					                (playerSize[secondPlayer - 1] + playerSize[thirdPlayer - 1]) * merge2Size);
					Destroy(droplet);
				}
			}
		}
		if (Input.GetKey(firstPlayerRight)){
			if (Input.GetKey(secondPlayerRight)){
				if (Input.GetKey(thirdPlayerRight)){
					//go right together
					droplet.transform.position += speedVector;
				}
				if (Input.GetKey(thirdPlayerLeft)){
					//third player goes left alone
					initiateDroplet("player" + thirdPlayer,
					                droplet.transform.position - disDifference,
					                playerSize[thirdPlayer - 1]);
					initiateDroplet("player" + firstPlayer + secondPlayer,
					                droplet.transform.position + disDifference,
					                (playerSize[firstPlayer - 1] + playerSize[secondPlayer - 1]) * merge2Size);
					Destroy(droplet);
				}
			}
			if (Input.GetKey(secondPlayerLeft)){
				if (Input.GetKey(thirdPlayerLeft)){
					//first player goes right alone
					initiateDroplet("player" + secondPlayer + thirdPlayer,
					                droplet.transform.position - disDifference,
					                (playerSize[secondPlayer - 1] + playerSize[thirdPlayer - 1]) * merge2Size);
					initiateDroplet("player" + firstPlayer,
					                droplet.transform.position + disDifference,
					                playerSize[firstPlayer - 1]);
					Destroy(droplet);
				}
				if (Input.GetKey(thirdPlayerRight)){
					//second player goes left alone
					initiateDroplet("player" + secondPlayer,
					                droplet.transform.position - disDifference,
					                playerSize[secondPlayer - 1]);
					initiateDroplet("player" + firstPlayer + thirdPlayer,
					                droplet.transform.position + disDifference,
					                (playerSize[firstPlayer - 1] + playerSize[thirdPlayer - 1]) * merge2Size);
					Destroy(droplet);
				}
			}
		}
		
		//control by controller
		if (isControllerConnected) {
			float firstPlayerMove = playerMove(firstPlayer);
			float secondPlayerMove = playerMove(secondPlayer);
			float thirdPlayerMove = playerMove(thirdPlayer);

			if ((firstPlayerMove <= 0 && secondPlayerMove <= 0 && thirdPlayerMove <= 0)
				||(firstPlayerMove >= 0 && secondPlayerMove >= 0 && thirdPlayerMove >= 0)){
				//move together
				float aveMove = (firstPlayerMove + secondPlayerMove + thirdPlayerMove) / 3;
				droplet.transform.position += new Vector3(aveMove * playerMoveSpeed, 0, 0);
			} else {
				//split up
				initiateDroplet("player" + firstPlayer,
				                droplet.transform.position + new Vector3((firstPlayerMove > 0 ? 1f : -1f), 0, 0),
				                playerSize[firstPlayer - 1]);
				initiateDroplet("player" + secondPlayer,
				                droplet.transform.position + new Vector3((secondPlayerMove > 0 ? 1f : -1f), 0, 0),
				                playerSize[secondPlayer - 1]);
				initiateDroplet("player" + thirdPlayer,
				                droplet.transform.position + new Vector3((thirdPlayer > 0 ? 1f : -1f), 0, 0),
				                playerSize[thirdPlayer - 1]);
				Destroy(droplet);
			}
		}
	}

	//control of 4 players
	void manipulate4Players(GameObject droplet) {
		//control by keyboard
		if (Input.GetKey(player1Left)){
			if (Input.GetKey(player2Left)){
				if (Input.GetKey(player3Left)){
					if (Input.GetKey(player4Left)){
						//Go left together
						droplet.transform.position -= speedVector;
					}
					if (Input.GetKey(player4Right)){
						//player4 goes right alone
						initiateDroplet("player123",
						                droplet.transform.position - disDifference,
						                (playerSize[0] + playerSize[1] + playerSize[2]) * merge3Size);
						initiateDroplet("player4",
						                droplet.transform.position + disDifference,
						                playerSize[3]);
						Destroy(droplet);
					}
				}
				if (Input.GetKey(player3Right)){
					if (Input.GetKey(player4Left)){
						//player3 goes right alone
						initiateDroplet("player124",
						                droplet.transform.position - disDifference,
						                (playerSize[0] + playerSize[1] + playerSize[3]) * merge3Size);
						initiateDroplet("player3",
						                droplet.transform.position + disDifference,
						                playerSize[2]);
						Destroy(droplet);
					}
					if (Input.GetKey(player4Right)){
						//player12 goes left, player34 goes right
						initiateDroplet("player12",
						                droplet.transform.position - disDifference,
						                (playerSize[0] + playerSize[1]) * merge2Size);
						initiateDroplet("player34",
						                droplet.transform.position + disDifference,
						                (playerSize[2] + playerSize[3]) * merge2Size);
						Destroy(droplet);
					}
				}
			}
			if (Input.GetKey(player2Right)){
				if (Input.GetKey(player3Left)){
					if (Input.GetKey(player4Left)){
						//player2 goes right alone
						initiateDroplet("player134",
						                droplet.transform.position - disDifference,
						                (playerSize[0] + playerSize[2] + playerSize[3]) * merge3Size);
						initiateDroplet("player2",
						                droplet.transform.position + disDifference,
						                playerSize[1]);
						Destroy(droplet);
					}
					if (Input.GetKey(player4Right)){
						//player13 goes left, player24 goes right
						initiateDroplet("player13",
						                droplet.transform.position - disDifference,
						                (playerSize[0] + playerSize[2]) * merge2Size);
						initiateDroplet("player24",
						                droplet.transform.position + disDifference,
						                (playerSize[1] + playerSize[3]) * merge2Size);
						Destroy(droplet);
					}
				}
				if (Input.GetKey(player3Right)){
					if (Input.GetKey(player4Left)){
						//player14 goes left, player23 goes right
						initiateDroplet("player14",
						                droplet.transform.position - disDifference,
						                (playerSize[0] + playerSize[3]) * merge2Size);
						initiateDroplet("player23",
						                droplet.transform.position + disDifference,
						                (playerSize[1] + playerSize[2]) * merge2Size);
						Destroy(droplet);
					}
					if (Input.GetKey(player4Right)){
						//player1 goes left alone
						initiateDroplet("player1",
						                droplet.transform.position - disDifference,
						                playerSize[0]);
						initiateDroplet("player234",
						                droplet.transform.position + disDifference,
						                (playerSize[1] + playerSize[2] + playerSize[3]) * merge3Size);
						Destroy(droplet);
					}
				}
			}
		}
		if (Input.GetKey(player1Right)){
			if (Input.GetKey(player2Right)){
				if (Input.GetKey(player3Right)){
					if (Input.GetKey(player4Right)){
						//Go right together
						droplet.transform.position += speedVector;
					}
					if (Input.GetKey(player4Left)){
						//player4 goes left alone
						initiateDroplet("player4",
						                droplet.transform.position - disDifference,
						                playerSize[3]);
						initiateDroplet("player123",
						                droplet.transform.position + disDifference,
						                (playerSize[0] + playerSize[1] + playerSize[2]) * merge3Size);
						Destroy(droplet);
					}
				}
				if (Input.GetKey(player3Left)){
					if (Input.GetKey(player4Right)){
						//player3 goes left alone
						initiateDroplet("player3",
						                droplet.transform.position - disDifference,
						                playerSize[2]);
						initiateDroplet("player124",
						                droplet.transform.position + disDifference,
						                (playerSize[0] + playerSize[1] + playerSize[3]) * merge3Size);
						Destroy(droplet);
					}
					if (Input.GetKey(player4Left)){
						//player34 goes left, player12 goes right
						initiateDroplet("player34",
						                droplet.transform.position - disDifference,
						                (playerSize[2] + playerSize[3]) * merge2Size);
						initiateDroplet("player12",
						                droplet.transform.position + disDifference,
						                (playerSize[0] + playerSize[1]) * merge2Size);
						Destroy(droplet);
					}
				}
			}
			if (Input.GetKey(player2Left)){
				if (Input.GetKey(player3Right)){
					if (Input.GetKey(player4Right)){
						//player2 goes left alone
						initiateDroplet("player2",
						                droplet.transform.position - disDifference,
						                playerSize[1]);
						initiateDroplet("player134",
						                droplet.transform.position + disDifference,
						                (playerSize[0] + playerSize[2] + playerSize[3]) * merge3Size);
						Destroy(droplet);
					}
					if (Input.GetKey(player4Left)){
						//player24 goes left, player13 goes right
						initiateDroplet("player24",
						                droplet.transform.position - disDifference,
						                (playerSize[1] + playerSize[3]) * merge2Size);
						initiateDroplet("player13",
						                droplet.transform.position + disDifference,
						                (playerSize[0] + playerSize[2]) * merge2Size);
						Destroy(droplet);
					}
				}
				if (Input.GetKey(player3Left)){
					if (Input.GetKey(player4Right)){
						//player23 goes left, player14 goes right
						initiateDroplet("player23",
						                droplet.transform.position - disDifference,
						                (playerSize[1] + playerSize[2]) * merge2Size);
						initiateDroplet("player14",
						                droplet.transform.position + disDifference,
						                (playerSize[0] + playerSize[3]) * merge2Size);
						Destroy(droplet);
					}
					if (Input.GetKey(player4Left)){
						//player1 goes right alone
						initiateDroplet("player234",
						                droplet.transform.position - disDifference,
						                (playerSize[1] + playerSize[2] + playerSize[3]) * merge3Size);
						initiateDroplet("player1",
						                droplet.transform.position + disDifference,
						                playerSize[0]);
						Destroy(droplet);
					}
				}
			}
		}

		//control by controller
		if (isControllerConnected) {
			if ((player1Move <= 0 && player2Move <= 0 && player3Move <= 0 && player4Move <= 0)
			    ||(player1Move >= 0 && player2Move >= 0 && player3Move >= 0 && player4Move >= 0)){
				//move together
				float aveMove = (player1Move + player2Move + player3Move + player4Move) / 4;
				droplet.transform.position += new Vector3(aveMove * playerMoveSpeed, 0, 0);
			} else {
				//split up
				initiateDroplet("player1",
				                droplet.transform.position + new Vector3((player1Move > 0 ? 1f : -1f), 0, 0),
				                playerSize[0]);
				initiateDroplet("player2",
				                droplet.transform.position + new Vector3((player2Move > 0 ? 1f : -1f), 0, 0),
				                playerSize[1]);
				initiateDroplet("player3",
				                droplet.transform.position + new Vector3((player3Move > 0 ? 1f : -1f), 0, 0),
				                playerSize[2]);
				initiateDroplet("player4",
				                droplet.transform.position + new Vector3((player4Move > 0 ? 1f : -1f), 0, 0),
				                playerSize[3]);
				Destroy(droplet);
			}
		}
	}
	
	// Use this for initialization
	void Start () {
		playerSize = new Vector3[4] {initialPlayerSize, initialPlayerSize, initialPlayerSize, initialPlayerSize};
		initiateDroplet ("player1", player1Pos, playerSize[0]);
		initiateDroplet ("player2", player2Pos, playerSize[1]);
		initiateDroplet ("player3", player3Pos, playerSize[2]);
		initiateDroplet ("player4", player4Pos, playerSize[3]);

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
	}
	
	// Update is called once per frame
	void Update () {
		//update the controller state
		if (isControllerConnected){
			player1Move = GamePad.GetState(GamePad.Index.One).LeftStickAxis.x;
			player2Move = GamePad.GetState(GamePad.Index.One).rightStickAxis.x;
			player3Move = GamePad.GetState(GamePad.Index.Two).LeftStickAxis.x;
			player4Move = GamePad.GetState(GamePad.Index.Two).rightStickAxis.x;
		}

		//manipulate droplets
		if (GameObject.Find ("player1") != null){
			Debug.Log("1");
			manipulate1Player(GameObject.Find ("player1"), 1);
		}
		if (GameObject.Find ("player2") != null){
			Debug.Log("2");
			manipulate1Player(GameObject.Find ("player2"), 2);
		}
		if (GameObject.Find ("player3") != null){
			Debug.Log("3");
			manipulate1Player(GameObject.Find ("player3"), 3);
		}
		if (GameObject.Find ("player4") != null){
			Debug.Log("4");
			manipulate1Player(GameObject.Find ("player4"), 4);
		}
		if (GameObject.Find ("player12") != null){
			manipulate2Players(GameObject.Find ("player12"), 1, 2);
		}
		if (GameObject.Find ("player13") != null){
			manipulate2Players(GameObject.Find ("player13"), 1, 3);
		}
		if (GameObject.Find ("player14") != null){
			manipulate2Players(GameObject.Find ("player14"), 1, 4);
		}
		if (GameObject.Find ("player23") != null){
			manipulate2Players(GameObject.Find ("player23"), 2, 3);
		}
		if (GameObject.Find ("player24") != null){
			manipulate2Players(GameObject.Find ("player24"), 2, 4);
		}
		if (GameObject.Find ("player34") != null){
			manipulate2Players(GameObject.Find ("player34"), 3, 4);
		}
		if (GameObject.Find ("player123") != null){
			manipulate3Players(GameObject.Find ("player123"), 1, 2, 3);
		}
		if (GameObject.Find ("player124") != null){
			manipulate3Players(GameObject.Find ("player124"), 1, 2, 4);
		}
		if (GameObject.Find ("player134") != null){
			manipulate3Players(GameObject.Find ("player134"), 1, 3, 4);
		}
		if (GameObject.Find ("player234") != null){
			manipulate3Players(GameObject.Find ("player234"), 2, 3, 4);
		}
		if (GameObject.Find ("player1234") != null){
			manipulate4Players(GameObject.Find ("player1234"));
		}
	}
}