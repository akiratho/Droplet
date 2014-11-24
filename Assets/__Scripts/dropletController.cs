using UnityEngine;
using System.Collections;
using XInputDotNetPure; 

public class dropletController : MonoBehaviour {
	public GameObject droplet;
	XInputTestCS inputController;
	bool isControllerConnected = false;
	
//	GameObject[] player;
	GameObject player1;
	GameObject player2;
	GameObject player3;
	GameObject player4;

//	GameObject[] playerMerge;
	GameObject playerMerge2_1;
	GameObject playerMerge2_2;
	GameObject playerMerge3;
	GameObject playerMerge4;
	
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
	
	//initialization for player1
	void initialPlayer1 (Vector3 position){
		player1 = Instantiate(droplet, position, Quaternion.identity) as GameObject;
		player1.tag = "Droplet";
	}
	//initialization for player2
	void initialPlayer2 (Vector3 position){
		player2 = Instantiate(droplet, position, Quaternion.identity) as GameObject;
		player2.tag = "Droplet";
	}
	//initialization for player3
	void initialPlayer3 (Vector3 position){
		player3 = Instantiate(droplet, position, Quaternion.identity) as GameObject;
		player3.tag = "Droplet";
	}
	//initialization for player4
	void initialPlayer4 (Vector3 position){
		player4 = Instantiate(droplet, position, Quaternion.identity) as GameObject;
		player4.tag = "Droplet";
	}
	
	//initialization for 2 droplets merge
	void initialMerge2_1(Vector3 position){
		playerMerge2_1 = Instantiate(droplet, position, Quaternion.identity) as GameObject;
		playerMerge2_1.transform.localScale += new Vector3(.3f, .3f, 0);
		playerMerge2_1.tag = "Droplet";
	}
	//initialization for 2 droplets merge when there's another 2 droplets merged
	void initialMerge2_2(Vector3 position){
		playerMerge2_2 = Instantiate(droplet, position, Quaternion.identity) as GameObject;
		playerMerge2_2.transform.localScale += new Vector3(.3f, .3f, 0);
		playerMerge2_2.tag = "Droplet";
	}
	//initialization for 3 droplets merge
	void initialMerge3(Vector3 position){
		playerMerge3 = Instantiate(droplet, position, Quaternion.identity) as GameObject;
		playerMerge3.transform.localScale += new Vector3(.6f, .6f, 0);
		playerMerge3.tag = "Droplet";
	}
	//initialization for 4 droplets merge
	void initialMerge4(Vector3 position){
		playerMerge4 = Instantiate(droplet, position, Quaternion.identity) as GameObject;
		playerMerge4.transform.localScale += new Vector3(.9f, .9f, 0);
		playerMerge4.tag = "Droplet";
	}

//	public void initialPlayer (int i, Vector3 position){
//		player[i] = Instantiate(droplet, position, Quaternion.identity) as GameObject;
//		player[i].tag = "Droplet";
//	}

//	public void mergePlayer (int i){
//		player [i] = null;
//	}
	
	//control of player1
	void manipulatePlayer1 (){
		if (isControllerConnected) {
			if (inputController.state.ThumbSticks.Left.X < 0){
				player1.transform.position -= new Vector3 (.03f, 0, 0);
			}
			if (inputController.state.ThumbSticks.Left.X > 0){
				player1.transform.position += new Vector3 (.03f, 0, 0);
			}
		} else {
			if (Input.GetKey(KeyCode.A)){
				player1.transform.position -= new Vector3 (.03f, 0, 0);
			}
			if (Input.GetKey(KeyCode.D)){
				player1.transform.position += new Vector3 (.03f, 0, 0);
			}
		}
	}
	//control of player2
	void manipulatePlayer2 (){
		if (isControllerConnected) {
			if (inputController.state.ThumbSticks.Right.X < 0){
				player2.transform.position -= new Vector3 (.03f, 0, 0);
			}
			if (inputController.state.ThumbSticks.Right.X > 0){
				player2.transform.position += new Vector3 (.03f, 0, 0);
			}
		} else {
			if (Input.GetKey(KeyCode.J)){
				player2.transform.position -= new Vector3 (.03f, 0, 0);
			}
			if (Input.GetKey(KeyCode.L)){
				player2.transform.position += new Vector3 (.03f, 0, 0);
			}
		}
	}
	//control of player3
	void manipulatePlayer3 (){
		if (isControllerConnected) {
			if (inputController.state.ThumbSticks.Left.Y > 0){
				player3.transform.position -= new Vector3 (.03f, 0, 0);
			}
			if (inputController.state.ThumbSticks.Left.Y < 0){
				player3.transform.position += new Vector3 (.03f, 0, 0);
			}
		} else {
			if (Input.GetKey(KeyCode.LeftArrow)){
				player3.transform.position -= new Vector3 (.03f, 0, 0);
			}
			if (Input.GetKey(KeyCode.RightArrow)){
				player3.transform.position += new Vector3 (.03f, 0, 0);
			}
		}
	}
	//control of player4
	void manipulatePlayer4 (){
		if (isControllerConnected) {
			if (inputController.state.ThumbSticks.Right.Y > 0){
				player4.transform.position -= new Vector3 (.03f, 0, 0);
			}
			if (inputController.state.ThumbSticks.Right.Y < 0){
				player4.transform.position += new Vector3 (.03f, 0, 0);
			}
		} else {
			if (Input.GetKey(KeyCode.Keypad4)){
				player4.transform.position -= new Vector3 (.03f, 0, 0);
			}
			if (Input.GetKey(KeyCode.Keypad6)){
				player4.transform.position += new Vector3 (.03f, 0, 0);
			}
		}
	}
	
	//add more situations about controll multi-players
	//control player1&2
	void manipulatePlayer12() {
		if (Input.GetKey(KeyCode.A)){
				if (Input.GetKey(KeyCode.J)){
					playerMerge2_1.transform.position -= new Vector3 (.03f, 0, 0);
				}
				if (Input.GetKey(KeyCode.L)){
					isMerge2 = false;
					initialPlayer1(playerMerge2_1.transform.position - new Vector3(1f, 0, 0));
					initialPlayer2(playerMerge2_1.transform.position + new Vector3(1f, 0, 0));
					Destroy(playerMerge2_1);
				}
			}
			if (Input.GetKey(KeyCode.D)){
				if (Input.GetKey(KeyCode.L)){
					playerMerge2_1.transform.position += new Vector3 (.03f, 0, 0);
				}
				if (Input.GetKey(KeyCode.J)){
					isMerge2 = false;
					initialPlayer1(playerMerge2_1.transform.position + new Vector3(1f, 0, 0));
					initialPlayer2(playerMerge2_1.transform.position - new Vector3(1f, 0, 0));
					Destroy(playerMerge2_1);
				}
			}
	}
	//control player1&3
	void manipulatePlayer13() {
		if (Input.GetKey(KeyCode.A)){
				if (Input.GetKey(KeyCode.LeftArrow)){
					playerMerge2_1.transform.position -= new Vector3 (.03f, 0, 0);
				}
				if (Input.GetKey(KeyCode.RightArrow)){
					isMerge2 = false;
					initialPlayer1(playerMerge2_1.transform.position - new Vector3(1f, 0, 0));
					initialPlayer3(playerMerge2_1.transform.position + new Vector3(1f, 0, 0));
					Destroy(playerMerge2_1);
				}
			}
			if (Input.GetKey(KeyCode.D)){
				if (Input.GetKey(KeyCode.RightArrow)){
					playerMerge2_1.transform.position += new Vector3 (.03f, 0, 0);
				}
				if (Input.GetKey(KeyCode.LeftArrow)){
					isMerge2 = false;
					initialPlayer1(playerMerge2_1.transform.position + new Vector3(1f, 0, 0));
					initialPlayer3(playerMerge2_1.transform.position - new Vector3(1f, 0, 0));
					Destroy(playerMerge2_1);
				}
			}
	}
	
	// Use this for initialization
	void Start () {
		initialPlayer1(new Vector3(-7f, 0, 0));
		initialPlayer2(new Vector3(-3f, 0, 0));
		initialPlayer3(new Vector3(4f, 0, 0));
		initialPlayer4(new Vector3(7f, 0, 0));
		inputController = gameObject.GetComponent("XInputTestCS") as XInputTestCS;
		if (inputController != null) {
			isControllerConnected = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Rocognize which droplet is merged with other droplet
		if (player1 == null) {
			if(player2 == null && player3 != null && player4 != null){
				//player1, player2 merge
				Debug.Log("1&2");
				setIsMerge2(true);
				manipulatePlayer12();
				manipulatePlayer3();
				manipulatePlayer4();
			} else if (player2 != null && player3 == null && player4 != null){
				//player1, player3 merge
				setIsMerge2(true);
				manipulatePlayer13();
				manipulatePlayer2();
				manipulatePlayer4();
			} else if (player2 != null && player3 != null && player4 == null){
				//player1, player4 merge
				setIsMerge2(true);
				manipulatePlayer2();
				manipulatePlayer3();
			} else if (player2 == null && player3 == null && player4 != null){
				//player1, player2, player3 merge
				setIsMerge3(true);
				manipulatePlayer4();
			} else if (player2 == null && player3 != null && player4 == null){
				//player1, player2, player4 merge
				setIsMerge3(true);
				manipulatePlayer3();
			} else if (player2 != null && player3 == null && player4 == null){
				//player1, player3, player4 merge
				setIsMerge3(true);
				manipulatePlayer2();
			} else if (player2 == null && player3 == null && player4 == null){
				//player1, player2, player3, player4 merge
				setIsMerge4(true);
			}
		}else if (player2 == null) {
			if(player3 == null && player4 != null){
				//player2, player3 merge
				setIsMerge2(true);
				manipulatePlayer1();
				manipulatePlayer4();
			} else if (player3 != null && player4 == null){
				//player2, player4 merge
				setIsMerge2(true);
				manipulatePlayer1();
				manipulatePlayer3();
			} else if (player3 == null && player4 == null){
				//player2, player3, player4 merge
				setIsMerge3(true);
				manipulatePlayer1();
			}
		} else if (player3 == null){
			//player3, player4 merge
			setIsMerge2(true);
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
				initialMerge2_1(collidePos);
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

//public class droplet : MonoBehaviour {
//	public Vector3 dropletPos;
//	public GameObject dropletSprite;
//
//	public void initialPlayer (GameObject sprite, Vector3 position){
//		dropletSprite = Instantiate(sprite, position, Quaternion.identity) as GameObject;
//		dropletSprite.tag = "Droplet";
//	}
//
//	void OnCollisionEnter2D(Collision2D collision) {
//		if(collision.gameObject.tag == "Droplet" && gameObject.tag == "Droplet"){
//			dropletController script = GameObject.Find("Player Droplets").GetComponent("dropletController") as dropletController;
//			script.setCollide(true, collision.transform.position);
//			script.setIsMerge2(true);
////			Destroy (gameObject);
//		}
//	}
//}
