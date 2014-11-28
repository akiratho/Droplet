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
	public float temp;

	public Vector3 player1Pos = new Vector3 (-7f, 0, 0);
	public Vector3 player2Pos = new Vector3 (-3f, 0, 0);
	public Vector3 player3Pos = new Vector3 (4f, 0, 0);
	public Vector3 player4Pos = new Vector3 (7f, 0, 0);

	public Vector3 merge2Size = new Vector3 (.3f, .3f, 0);
	public Vector3 merge3Size = new Vector3 (.6f, .6f, 0);
	public Vector3 merge4Size = new Vector3 (.9f, .9f, 0);

	public Vector3 speedVector = new Vector3 (.03f, 0, 0);
	
	public GameObject[] player;
	public GameObject[] playerMerge2;
	public int[] merged2Players;
	public GameObject playerMerge3;
	public int[] merged3Players;
	public GameObject playerMerge4;
	
	bool isCollide = false;
	Vector3 collidePos;
	
	bool isMerge2 = false;
	bool isMerge3 = false;
	bool isMerge4 = false;
	
	//set variables for colliding
	public void setCollide(bool isColliding, Vector3 position) {
		isCollide = isColliding;
		collidePos = position;
	}
	
	//change the variable when 2 droplets merge
	void setIsMerge2(bool temp) {
		isMerge2 = temp;
		isMerge3 = !temp;
		isMerge4 = !temp;
	}
	//change the variable when 3 droplets merge
	void setIsMerge3(bool temp) {
		isMerge3 = temp;
		isMerge2 = !temp;
		isMerge4 = !temp;
	}
	//change the variable when 4 droplets merge
	void setIsMerge4(bool temp) {
		isMerge4 = temp;
		isMerge2 = !temp;
		isMerge3 = !temp;
	}

	//initialization for player
	void initialPlayer (int i, Vector3 position){
		player[i] = Instantiate(droplet, position, Quaternion.identity) as GameObject;
		player[i].tag = tagDroplet;
		player [i].name = "player" + i;
	}
	
	//initialization for 2 droplets merge
	void initialMerge2(Vector3 position){
		int index;
		if (playerMerge2[0] == null) {
			index = 0;
		} else {
			index = 1;
		}
		playerMerge2[index] = Instantiate(droplet, position, Quaternion.identity) as GameObject;
		playerMerge2[index].transform.localScale += merge2Size;
		playerMerge2[index].tag = tagDroplet;
		switch (index){
		case 0:
			playerMerge2[0].name = "player" + merged2Players[0] + merged2Players[1];
			break;
		case 1:
			playerMerge2[1].name = "player" + merged2Players[2] + merged2Players[3];
			break;
		}
		
	}

	//initialization for 3 droplets merge
	void initialMerge3(Vector3 position){
		playerMerge3 = Instantiate(droplet, position, Quaternion.identity) as GameObject;
		playerMerge3.transform.localScale += merge3Size;
		playerMerge3.tag = tagDroplet;
		playerMerge3.name = "player" + merged3Players[0] + merged3Players[1] + merged3Players[2];
	}
	//initialization for 4 droplets merge
	void initialMerge4(Vector3 position){
		playerMerge4 = Instantiate(droplet, position, Quaternion.identity) as GameObject;
		playerMerge4.transform.localScale += merge4Size;
		playerMerge4.tag = tagDroplet;
		playerMerge4.name = "player0123";
	}

//	public void mergePlayer (int i){
//		player [i] = null;
//	}
	
	//control of player1
	void manipulatePlayer1 (){
//			temp = GamePad.GetState.LeftStickAxis.x;
//			player[0].transform.position += new Vector3(temp*0.1f, 0, 0);
//		if (isControllerConnected) {
//			if (inputController.state.ThumbSticks.Left.X < 0){
//				player[0].transform.position -= speedVector;
//			}
//			if (inputController.state.ThumbSticks.Left.X > 0){
//				player[0].transform.position += speedVector;
//			}
//		} else {
			if (Input.GetKey(player1Left)){
				player[0].transform.position -= speedVector;
			}
			if (Input.GetKey(player1Right)){
				player[0].transform.position += speedVector;
			}
//		}
	}
	//control of player2
	void manipulatePlayer2 (){
		if (isControllerConnected) {
//			if (inputController.state.ThumbSticks.Right.X < 0){
//				player[1].transform.position -= speedVector;
//			}
//			if (inputController.state.ThumbSticks.Right.X > 0){
//				player[1].transform.position += speedVector;
//			}
		} else {
			if (Input.GetKey(player2Left)){
				player[1].transform.position -= speedVector;
			}
			if (Input.GetKey(player2Right)){
				player[1].transform.position += speedVector;
			}
		}
	}
	//control of player3
	void manipulatePlayer3 (){
		if (isControllerConnected) {
//			if (inputController.state.ThumbSticks.Left.Y > 0){
//				player[2].transform.position -= speedVector;
//			}
//			if (inputController.state.ThumbSticks.Left.Y < 0){
//				player[2].transform.position += speedVector;
//			}
		} else {
			if (Input.GetKey(player3Left)){
				player[2].transform.position -= speedVector;
			}
			if (Input.GetKey(player3Right)){
				player[2].transform.position += speedVector;
			}
		}
	}
	//control of player4
	void manipulatePlayer4 (){
		if (isControllerConnected) {
//			if (inputController.state.ThumbSticks.Right.Y > 0){
//				player[3].transform.position -= speedVector;
//			}
//			if (inputController.state.ThumbSticks.Right.Y < 0){
//				player[3].transform.position += speedVector;
//			}
		} else {
			if (Input.GetKey(player4Left)){
				player[3].transform.position -= speedVector;
			}
			if (Input.GetKey(player4Right)){
				player[3].transform.position += speedVector;
			}
		}
	}
	
	//control of 2 players
	void manipulate2Players(int merge2Index, int firstPlayer, int secondPlayer) {
		KeyCode firstPlayerLeft = player1Left;
		KeyCode firstPlayerRight = player1Right;
		KeyCode secondPlayerLeft = player2Left;
		KeyCode secondPlayerRight = player2Right;

		switch (firstPlayer) {
		case 0:
			firstPlayerLeft = player1Left;
			firstPlayerRight = player1Right;
			break;
		case 1:
			firstPlayerLeft = player2Left;
			firstPlayerRight = player2Right;
			break;
		case 2:
			firstPlayerLeft = player3Left;
			firstPlayerRight = player3Right;
			break;
		case 3:
			firstPlayerLeft = player4Left;
			firstPlayerRight = player4Right;
			break;
		}

		switch (secondPlayer) {
		case 0:
			secondPlayerLeft = player1Left;
			secondPlayerRight = player1Right;
			break;
		case 1:
			secondPlayerLeft = player2Left;
			secondPlayerRight = player2Right;
			break;
		case 2:
			secondPlayerLeft = player3Left;
			secondPlayerRight = player3Right;
			break;
		case 3:
			secondPlayerLeft = player4Left;
			secondPlayerRight = player4Right;
			break;
		}

		if (Input.GetKey(firstPlayerLeft)){
			if (Input.GetKey(secondPlayerLeft)){
				playerMerge2[merge2Index].transform.position -= speedVector;
			}
			if (Input.GetKey(secondPlayerRight)){
				isMerge2 = false;
				initialPlayer(firstPlayer, playerMerge2[merge2Index].transform.position - new Vector3(1f, 0, 0));
				initialPlayer(secondPlayer, playerMerge2[merge2Index].transform.position + new Vector3(1f, 0, 0));
				merged2Players = new int[4];
				Destroy(playerMerge2[merge2Index]);
			}
		}
		if (Input.GetKey(firstPlayerRight)){
			if (Input.GetKey(secondPlayerRight)){
				playerMerge2[merge2Index].transform.position += speedVector;
			}
			if (Input.GetKey(secondPlayerLeft)){
				isMerge2 = false;
				initialPlayer(firstPlayer, playerMerge2[merge2Index].transform.position + new Vector3(1f, 0, 0));
				initialPlayer(secondPlayer, playerMerge2[merge2Index].transform.position - new Vector3(1f, 0, 0));
				merged2Players = new int[4];
				Destroy(playerMerge2[merge2Index]);
			}
		}
	}

	//control of 3 players
	void manipulate3Players(int firstPlayer, int secondPlayer, int thirdPlayer) {
		KeyCode firstPlayerLeft = player1Left;
		KeyCode firstPlayerRight = player1Right;
		KeyCode secondPlayerLeft = player2Left;
		KeyCode secondPlayerRight = player2Right;
		KeyCode thirdPlayerLeft = player3Left;
		KeyCode thirdPlayerRight = player3Right;
		
		switch (firstPlayer) {
		case 0:
			firstPlayerLeft = player1Left;
			firstPlayerRight = player1Right;
			break;
		case 1:
			firstPlayerLeft = player2Left;
			firstPlayerRight = player2Right;
			break;
		case 2:
			firstPlayerLeft = player3Left;
			firstPlayerRight = player3Right;
			break;
		case 3:
			firstPlayerLeft = player4Left;
			firstPlayerRight = player4Right;
			break;
		}
		
		switch (secondPlayer) {
		case 0:
			secondPlayerLeft = player1Left;
			secondPlayerRight = player1Right;
			break;
		case 1:
			secondPlayerLeft = player2Left;
			secondPlayerRight = player2Right;
			break;
		case 2:
			secondPlayerLeft = player3Left;
			secondPlayerRight = player3Right;
			break;
		case 3:
			secondPlayerLeft = player4Left;
			secondPlayerRight = player4Right;
			break;
		}

		switch (thirdPlayer) {
		case 0:
			thirdPlayerLeft = player1Left;
			thirdPlayerRight = player1Right;
			break;
		case 1:
			thirdPlayerLeft = player2Left;
			thirdPlayerRight = player2Right;
			break;
		case 2:
			thirdPlayerLeft = player3Left;
			thirdPlayerRight = player3Right;
			break;
		case 3:
			thirdPlayerLeft = player4Left;
			thirdPlayerRight = player4Right;
			break;
		}
		
		if (Input.GetKey(firstPlayerLeft)){
			if (Input.GetKey(secondPlayerLeft)){
				if (Input.GetKey(thirdPlayerLeft)){
					//Go left together
					playerMerge3.transform.position -= speedVector;
				}
				if (Input.GetKey(thirdPlayerRight)){
					//third player goes right alone
					isMerge3 = false;
					isMerge2 = true;
					merged2Players[0] = firstPlayer;
					merged2Players[1] = secondPlayer;
					initialMerge2(playerMerge3.transform.position - new Vector3(1f, 0, 0));
					initialPlayer(thirdPlayer, playerMerge3.transform.position + new Vector3(1f, 0, 0));
					Destroy(playerMerge3);
				}
			}
			if (Input.GetKey(secondPlayerRight)){
				if (Input.GetKey(thirdPlayerLeft)){
					//second player goes right alone
					isMerge3 = false;
					isMerge2 = true;
					merged2Players[0] = firstPlayer;
					merged2Players[1] = thirdPlayer;
					initialMerge2(playerMerge3.transform.position - new Vector3(1f, 0, 0));
					initialPlayer(secondPlayer, playerMerge3.transform.position + new Vector3(1f, 0, 0));
					Destroy(playerMerge3);
				}
				if (Input.GetKey(thirdPlayerRight)){
					//first player goes left alone
					isMerge3 = false;
					isMerge2 = true;
					initialPlayer(firstPlayer, playerMerge3.transform.position - new Vector3(1f, 0, 0));
					merged2Players[0] = secondPlayer;
					merged2Players[1] = thirdPlayer;
					initialMerge2(playerMerge3.transform.position + new Vector3(1f, 0, 0));
					Destroy(playerMerge3);
				}
			}
		}
		if (Input.GetKey(firstPlayerRight)){
			if (Input.GetKey(secondPlayerRight)){
				if (Input.GetKey(thirdPlayerRight)){
					//go right together
					playerMerge3.transform.position += speedVector;
				}
				if (Input.GetKey(thirdPlayerLeft)){
					//third player goes left alone
					isMerge3 = false;
					isMerge2 = true;
					initialPlayer(thirdPlayer, playerMerge3.transform.position - new Vector3(1f, 0, 0));
					merged2Players[0] = firstPlayer;
					merged2Players[1] = secondPlayer;
					initialMerge2(playerMerge3.transform.position + new Vector3(1f, 0, 0));
					Destroy(playerMerge3);
				}
			}
			if (Input.GetKey(secondPlayerLeft)){
				if (Input.GetKey(thirdPlayerLeft)){
					//first player goes right alone
					isMerge3 = false;
					isMerge2 = true;
					merged2Players[0] = secondPlayer;
					merged2Players[1] = thirdPlayer;
					initialMerge2(playerMerge3.transform.position - new Vector3(1f, 0, 0));
					initialPlayer(firstPlayer, playerMerge3.transform.position + new Vector3(1f, 0, 0));
					Destroy(playerMerge3);
				}
				if (Input.GetKey(thirdPlayerRight)){
					//second player goes left alone
					isMerge3 = false;
					isMerge2 = true;
					initialPlayer(secondPlayer, playerMerge3.transform.position - new Vector3(1f, 0, 0));
					merged2Players[0] = firstPlayer;
					merged2Players[1] = thirdPlayer;
					initialMerge2(playerMerge3.transform.position + new Vector3(1f, 0, 0));
					Destroy(playerMerge3);
				}
			}
		}
	}

	//control of 4 players
	void manipulate4Players() {
		if (Input.GetKey(player1Left)){
			if (Input.GetKey(player2Left)){
				if (Input.GetKey(player3Left)){
					if (Input.GetKey(player4Left)){
						//Go left together
						playerMerge4.transform.position -= speedVector;
					}
					if (Input.GetKey(player4Right)){
						//player4 goes right alone
						isMerge4 = false;
						isMerge3 = true;
						merged3Players = new int[3]{0, 1, 2};
						initialMerge3(playerMerge4.transform.position - new Vector3(1f, 0, 0));
						initialPlayer(3, playerMerge4.transform.position + new Vector3(1f, 0, 0));
						Destroy(playerMerge4);
					}
				}
				if (Input.GetKey(player3Right)){
					if (Input.GetKey(player4Left)){
						//player3 goes right alone
						isMerge4 = false;
						isMerge3 = true;
						merged3Players = new int[3]{0, 1, 3};
						initialMerge3(playerMerge4.transform.position - new Vector3(1f, 0, 0));
						initialPlayer(2, playerMerge4.transform.position + new Vector3(1f, 0, 0));
						Destroy(playerMerge4);
					}
					if (Input.GetKey(player4Right)){
						//player12 goes left, player34 goes right
						isMerge4 = false;
						isMerge2 = true;
						merged2Players = new int[4]{0,1,2,3};
						initialMerge2(playerMerge4.transform.position - new Vector3(1f, 0, 0));
						initialMerge2(playerMerge4.transform.position + new Vector3(1f, 0, 0));
						Destroy(playerMerge4);
					}
				}
			}
			if (Input.GetKey(player2Right)){
				if (Input.GetKey(player3Left)){
					if (Input.GetKey(player4Left)){
						//player2 goes right alone
						isMerge4 = false;
						isMerge3 = true;
						merged3Players = new int[3]{0, 2, 3};
						initialMerge3(playerMerge4.transform.position - new Vector3(1f, 0, 0));
						initialPlayer(1, playerMerge4.transform.position + new Vector3(1f, 0, 0));
						Destroy(playerMerge4);
					}
					if (Input.GetKey(player4Right)){
						//player13 goes left, player24 goes right
						isMerge4 = false;
						isMerge2 = true;
						merged2Players = new int[4]{0,2,1,3};
						initialMerge2(playerMerge4.transform.position - new Vector3(1f, 0, 0));
						initialMerge2(playerMerge4.transform.position + new Vector3(1f, 0, 0));
						Destroy(playerMerge4);
					}
				}
				if (Input.GetKey(player3Right)){
					if (Input.GetKey(player4Left)){
						//player14 goes left, player23 goes right
						isMerge4 = false;
						isMerge2 = true;
						merged2Players = new int[4]{0,3,1,2};
						initialMerge2(playerMerge4.transform.position - new Vector3(1f, 0, 0));
						initialMerge2(playerMerge4.transform.position + new Vector3(1f, 0, 0));
						Destroy(playerMerge4);
					}
					if (Input.GetKey(player4Right)){
						//player1 goes left alone
						isMerge4 = false;
						isMerge3 = true;
						merged3Players = new int[3]{1, 2, 3};
						initialPlayer(0, playerMerge4.transform.position - new Vector3(1f, 0, 0));
						initialMerge3(playerMerge4.transform.position + new Vector3(1f, 0, 0));
						Destroy(playerMerge4);
					}
				}
			}
		}
		if (Input.GetKey(player1Right)){
			if (Input.GetKey(player2Right)){
				if (Input.GetKey(player3Right)){
					if (Input.GetKey(player4Right)){
						//Go right together
						playerMerge4.transform.position += speedVector;
					}
					if (Input.GetKey(player4Left)){
						//player4 goes alone
						isMerge4 = false;
						isMerge3 = true;
						initialPlayer(3, playerMerge4.transform.position - new Vector3(1f, 0, 0));
						initialMerge3(playerMerge4.transform.position + new Vector3(1f, 0, 0));
						Destroy(playerMerge4);
					}
				}
//				if (Input.GetKey(player3Left)){
//					if (Input.GetKey(player4Right)){
//						//Go right together
//						playerMerge4.transform.position += speedVector;
//					}
//					if (Input.GetKey(player4Left)){
//						//player4 goes alone
//						isMerge4 = false;
//						isMerge3 = true;
//						initialPlayer(3, playerMerge4.transform.position - new Vector3(1f, 0, 0));
//						initialMerge3(playerMerge4.transform.position + new Vector3(1f, 0, 0));
//						Destroy(playerMerge4);
//					}
//				}
			}
//			if (Input.GetKey(player2Right)){
//				if (Input.GetKey(player3Right)){
//					if (Input.GetKey(player4Right)){
//						//Go right together
//						playerMerge4.transform.position += speedVector;
//					}
//					if (Input.GetKey(player4Left)){
//						//player4 goes alone
//						isMerge4 = false;
//						isMerge3 = true;
//						initialPlayer(3, playerMerge4.transform.position - new Vector3(1f, 0, 0));
//						initialMerge3(playerMerge4.transform.position + new Vector3(1f, 0, 0));
//						Destroy(playerMerge4);
//					}
//				}
//				if (Input.GetKey(player3Left)){
//					if (Input.GetKey(player4Right)){
//						//Go right together
//						playerMerge4.transform.position += speedVector;
//					}
//					if (Input.GetKey(player4Left)){
//						//player4 goes alone
//						isMerge4 = false;
//						isMerge3 = true;
//						initialPlayer(3, playerMerge4.transform.position - new Vector3(1f, 0, 0));
//						initialMerge3(playerMerge4.transform.position + new Vector3(1f, 0, 0));
//						Destroy(playerMerge4);
//					}
//				}
//				
//			}
		}
	}
	
	// Use this for initialization
	void Start () {
		player = new GameObject[4];
		initialPlayer (0, player1Pos);
		initialPlayer (1, player2Pos);
		initialPlayer (2, player3Pos);
		initialPlayer (3, player4Pos);
		playerMerge2 = new GameObject[2];
		playerMerge2 [0] = null;
		playerMerge2 [1] = null;
		merged2Players = new int[4];
		merged3Players = new int[3];
//		inputController = gameObject.GetComponent("XInputTestCS") as XInputTestCS;
//		if (inputController != null) {
//			isControllerConnected = true;
//		}
	}
	
	// Update is called once per frame
	void Update () {
		//Rocognize which droplet is merged with other droplet
		if (player[0] == null) {
			if(player[1] == null && player[2] != null && player[3] != null){
				//player1, player2 merge
				Debug.Log("1&2");
				merged2Players[0] = 0;
				merged2Players[1] = 1;
				setIsMerge2(true);
				manipulate2Players(0, 0, 1); 
				manipulatePlayer3();
				manipulatePlayer4();
			} else if (player[1] != null && player[2] == null && player[3] != null){
				//player1, player3 merge
				merged2Players[0] = 0;
				merged2Players[1] = 2;
				setIsMerge2(true);
				manipulate2Players(0, 0, 2); 
				manipulatePlayer2();
				manipulatePlayer4();
			} else if (player[1] != null && player[2] != null && player[3] == null){
				//player1, player4 merge
				merged2Players[0] = 0;
				merged2Players[1] = 3;
				setIsMerge2(true);
				manipulate2Players(0, 0, 3); 
				manipulatePlayer2();
				manipulatePlayer3();
			} else if (player[1] == null && player[2] == null && player[3] != null){
				//player1, player2, player3 merge
				merged3Players = new int[3]{0, 1, 2};
				setIsMerge3(true);
				manipulate3Players(0, 1, 2);
				manipulatePlayer4();
			} else if (player[1] == null && player[2] != null && player[3] == null){
				//player1, player2, player4 merge
				merged3Players = new int[3]{0, 1, 3};
				setIsMerge3(true);
				manipulate3Players(0, 1, 3);
				manipulatePlayer3();
			} else if (player[1] != null && player[2] == null && player[3] == null){
				//player1, player3, player4 merge
				merged3Players = new int[3]{0, 2, 3};
				setIsMerge3(true);
				manipulate3Players(0, 2, 3);
				manipulatePlayer2();
			} else if (player[1] == null && player[2] == null && player[3] == null){
				//2 players merge and 2 other players merge
				if (playerMerge2[0] != null && playerMerge2[1] == null) {
					for (int i = 0; i <= 3; i++){
						if (merged2Players[0] != i && merged2Players[1] != i){
							merged2Players[2] = i;
							break;
						}
					}
					for (int i = 0; i <= 3; i++){
						if (merged2Players[0] != i && merged2Players[1] != i && merged2Players[2] != i){
							merged2Players[3] = i;
							break;
						}
					}
					setIsMerge2(true);
				} else if(playerMerge2[0] != null && playerMerge2[1] != null){
					manipulate2Players(0, merged2Players[0], merged2Players[1]);
					manipulate2Players(1, merged2Players[2], merged2Players[3]);
				} else {
					//player1, player2, player3, player4 merge
					setIsMerge4(true);
					manipulate4Players();
				}
			}
		}else if (player[1] == null) {
			if(player[2] == null && player[3] != null){
				//player2, player3 merge
				merged2Players[0] = 1;
				merged2Players[1] = 2;
				setIsMerge2(true);
				manipulate2Players(0, 1, 2); 
				manipulatePlayer1();
				manipulatePlayer4();
			} else if (player[2] != null && player[3] == null){
				//player2, player4 merge
				merged2Players[0] = 1;
				merged2Players[1] = 3;
				setIsMerge2(true);
				manipulate2Players(0, 1, 3); 
				manipulatePlayer1();
				manipulatePlayer3();
			} else if (player[2] == null && player[3] == null){
				//player2, player3, player4 merge
				merged3Players = new int[3]{1, 2, 3};
				setIsMerge3(true);
				manipulate3Players(1, 2, 3);
				manipulatePlayer1();
			}
		} else if (player[2] == null){
			//player3, player4 merge
			merged2Players[0] = 2;
			merged2Players[1] = 3;
			setIsMerge2(true);
			manipulate2Players(0, 2, 3); 
			manipulatePlayer1();
			manipulatePlayer2();
		} else {
			//no droplet merges
			manipulatePlayer1();
			manipulatePlayer2();
			manipulatePlayer3();
			manipulatePlayer4();
		}
		
		//initial the merged droplet
		if (isMerge2) {
			if (isCollide){
				initialMerge2(collidePos);
				isCollide = false;
			}
		} else if (isMerge3) {
			if (isCollide){
				initialMerge3(collidePos);
				isCollide = false;
			}
		} else if (isMerge4) {
			if (isCollide){
				initialMerge4(collidePos);
				isCollide = false;
			}
		}
	}
}