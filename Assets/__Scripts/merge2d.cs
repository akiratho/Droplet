using UnityEngine;
using System.Collections;

public class merge2d : MonoBehaviour {
	
	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Droplet"){
			Debug.Log (collision.collider);
			dropletController script = GameObject.Find("Player Droplets").GetComponent("dropletController") as dropletController;
//			Debug.Log (gameObject);
//			Debug.Log (collision.gameObject);
			if ((gameObject.name == "player1")&&(collision.gameObject.name == "player2")
				||(gameObject.name == "player2")&&(collision.gameObject.name == "player1")) {
				if (GameObject.Find ("player12") == null){
					script.initiateDroplet("player12",
						                   collision.transform.position,
						                   (script.playerSize[0] + script.playerSize[1]) * script.merge2Size);
				}
			} else if ((gameObject.name == "player1")&&(collision.gameObject.name == "player3")
				       ||(gameObject.name == "player3")&&(collision.gameObject.name == "player1")) {
				if (GameObject.Find ("player13") == null){
					script.initiateDroplet("player13",
						                   collision.transform.position,
						                   (script.playerSize[0] + script.playerSize[2]) * script.merge2Size);
				}
			} else if ((gameObject.name == "player1")&&(collision.gameObject.name == "player4")
				       ||(gameObject.name == "player4")&&(collision.gameObject.name == "player1")) {
				if (GameObject.Find ("player14") == null){
					script.initiateDroplet("player14",
						                   collision.transform.position,
						                   (script.playerSize[0] + script.playerSize[3]) * script.merge2Size);
				}
			} else if ((gameObject.name == "player2")&&(collision.gameObject.name == "player3")
				       ||(gameObject.name == "player3")&&(collision.gameObject.name == "player2")) {
				if (GameObject.Find ("player23") == null){
					script.initiateDroplet("player23",
						                   collision.transform.position,
						                   (script.playerSize[1] + script.playerSize[2]) * script.merge2Size);
				}
			} else if ((gameObject.name == "player2")&&(collision.gameObject.name == "player4")
				       ||(gameObject.name == "player4")&&(collision.gameObject.name == "player2")) {
				if (GameObject.Find ("player24") == null){
					script.initiateDroplet("player24",
						                   collision.transform.position,
						                   (script.playerSize[1] + script.playerSize[3]) * script.merge2Size);
				}
			} else if ((gameObject.name == "player3")&&(collision.gameObject.name == "player4")
				       ||(gameObject.name == "player4")&&(collision.gameObject.name == "player3")) {
				if (GameObject.Find ("player34") == null){
					script.initiateDroplet("player34",
						                   collision.transform.position,
						                   (script.playerSize[2] + script.playerSize[3]) * script.merge2Size);
				}
			} else if ((gameObject.name == "player12")&&(collision.gameObject.name == "player3")
			           ||(gameObject.name == "player13")&&(collision.gameObject.name == "player2")
			           ||(gameObject.name == "player23")&&(collision.gameObject.name == "player1")
				       ||(gameObject.name == "player3")&&(collision.gameObject.name == "player12")
			           ||(gameObject.name == "player2")&&(collision.gameObject.name == "player13")
			           ||(gameObject.name == "player1")&&(collision.gameObject.name == "player23")) {
				if (GameObject.Find ("player123") == null){
					script.initiateDroplet("player123",
						                   collision.transform.position,
						                   (script.playerSize[0] + script.playerSize[1] + script.playerSize[2]) * script.merge3Size);
				}
			} else if ((gameObject.name == "player12")&&(collision.gameObject.name == "player4")
			           ||(gameObject.name == "player14")&&(collision.gameObject.name == "player2")
			           ||(gameObject.name == "player24")&&(collision.gameObject.name == "player1")
				       ||(gameObject.name == "player4")&&(collision.gameObject.name == "player12")
			           ||(gameObject.name == "player2")&&(collision.gameObject.name == "player14")
			           ||(gameObject.name == "player1")&&(collision.gameObject.name == "player24")) {
				if (GameObject.Find ("player124") == null){
					script.initiateDroplet("player124",
						                   collision.transform.position,
						                   (script.playerSize[0] + script.playerSize[1] + script.playerSize[3]) * script.merge3Size);
				}
			} else if ((gameObject.name == "player13")&&(collision.gameObject.name == "player4")
			           ||(gameObject.name == "player14")&&(collision.gameObject.name == "player3")
			           ||(gameObject.name == "player34")&&(collision.gameObject.name == "player1")
				       ||(gameObject.name == "player4")&&(collision.gameObject.name == "player13")
			           ||(gameObject.name == "player3")&&(collision.gameObject.name == "player14")
			           ||(gameObject.name == "player1")&&(collision.gameObject.name == "player34")) {
				if (GameObject.Find ("player134") == null){
					script.initiateDroplet("player134",
						                   collision.transform.position,
						                   (script.playerSize[0] + script.playerSize[2] + script.playerSize[3]) * script.merge3Size);
				}
			} else if ((gameObject.name == "player23")&&(collision.gameObject.name == "player4")
			           ||(gameObject.name == "player24")&&(collision.gameObject.name == "player3")
			           ||(gameObject.name == "player34")&&(collision.gameObject.name == "player2")
				       ||(gameObject.name == "player4")&&(collision.gameObject.name == "player23")
			           ||(gameObject.name == "player3")&&(collision.gameObject.name == "player24")
			           ||(gameObject.name == "player2")&&(collision.gameObject.name == "player34")) {
				if (GameObject.Find ("player234") == null){
					script.initiateDroplet("player234",
						                   collision.transform.position,
						                   (script.playerSize[1] + script.playerSize[2] + script.playerSize[3]) * script.merge3Size);
				}
			} else if ((gameObject.name == "player123")&&(collision.gameObject.name == "player4")
			           ||(gameObject.name == "player124")&&(collision.gameObject.name == "player3")
			           ||(gameObject.name == "player134")&&(collision.gameObject.name == "player2")
			           ||(gameObject.name == "player234")&&(collision.gameObject.name == "player1")
				       ||(gameObject.name == "player4")&&(collision.gameObject.name == "player123")
			           ||(gameObject.name == "player3")&&(collision.gameObject.name == "player124")
			           ||(gameObject.name == "player2")&&(collision.gameObject.name == "player134")
			           ||(gameObject.name == "player1")&&(collision.gameObject.name == "player234")
			           ||(gameObject.name == "player12")&&(collision.gameObject.name == "player34")
			           ||(gameObject.name == "player13")&&(collision.gameObject.name == "player24")
			           ||(gameObject.name == "player14")&&(collision.gameObject.name == "player23")
				       ||(gameObject.name == "player34")&&(collision.gameObject.name == "player12")
			           ||(gameObject.name == "player24")&&(collision.gameObject.name == "player13")
			           ||(gameObject.name == "player23")&&(collision.gameObject.name == "player14")) {
				if (GameObject.Find ("player1234") == null){
					script.initiateDroplet("player1234",
						                   collision.transform.position,
						                   (script.playerSize[0] + script.playerSize[1] + script.playerSize[2] + script.playerSize[3]) * script.merge4Size);
				}
			}
			Destroy (gameObject);
			Destroy (collision.gameObject);
		}
		if (collision.gameObject.tag == "dropCollect"){
			Debug.Log (collision.collider);
			scoreCal score = GameObject.Find("Player Droplets").GetComponent("scoreCal") as scoreCal;
			score.addScore(gameObject.name, 1);
			Destroy (collision.gameObject);
		}
	}
}