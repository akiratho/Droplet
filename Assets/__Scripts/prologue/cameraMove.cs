using UnityEngine;
using System.Collections;

public class cameraMove : MonoBehaviour {
	public Vector3 initPos = new Vector3 (0f, 1.15f, -10f);
	public Vector3 targetPos = new Vector3 (0f, -30f, -10f);
	dropCollect drops;
	float time;

	// Use this for initialization
	void Start () {
		gameObject.transform.position = initPos;
		drops = GameObject.Find("drop").GetComponent("dropCollect") as dropCollect;
		iTween.Init(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if (drops.levelFinished) {
//			gameObject.transform.position = new Vector3 (0f, -30f, -10f);
//			iTween.MoveTo (gameObject, iTween.Hash ("y", -30f, "time", 10f));
			iTween.MoveTo (gameObject, targetPos, 15f);
			time = Time.time;
		}
		
		if (gameObject.transform.position.y <= -25f) {
				Debug.Log("loadLevel2");
				Application.LoadLevel("Mini-GamePerformance");
			}
	}
}