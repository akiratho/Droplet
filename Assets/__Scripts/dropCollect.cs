using UnityEngine;
using System.Collections;

public class dropCollect : MonoBehaviour {
	public GameObject drop;
	public GameObject[] drops;
	public int dropsNum = 30;
	public float xRangeMin = -10f;
	public float xRangeMax = 10f;
	public float yRangeMin = 5.7f;
	public float yRangeMax = 7f;
	public float gravityRangeMin = 0.05f;
	public float gravityRangeMax = 0.3f;
	public float timeInterval = 0.3f;
	
	public bool levelFinished = false;

	// Use this for initialization
	IEnumerator Start () {
		drops = new GameObject[dropsNum];
		for (int i = 0; i < dropsNum; i++){
			float posX = Random.Range(xRangeMin, xRangeMax);
			float posY = Random.Range(yRangeMin, yRangeMax);
			Vector3 pos = new Vector3(posX, posY, 0f);
			drops[i] = Instantiate(drop, pos, Quaternion.identity) as GameObject;
			drops[i].rigidbody2D.gravityScale = Random.Range(gravityRangeMin, gravityRangeMax);
			drops[i].name = "dewDrop";
			yield return new WaitForSeconds(timeInterval);
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find("dewDrop") == null) {
			GameObject.Find("Clouds BG").collider2D.enabled = false;
			levelFinished = true;
		}
	}
}
