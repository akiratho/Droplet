using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BabyBird : MonoBehaviour {

	public GameObject				lBird; //Left Bird
	public GameObject				mBird; //Middle Bird
	public GameObject				rBird; //Right Bird

	public GameObject				lNest; //Left Nest
	public GameObject				mNest; //Middle Nest
	public GameObject				rNest; //Right Nest

	public GameObject				lLeaf; //Left Leaf
	public GameObject				mLeaf; //Mid Leaf
	public GameObject				rLeaf; //Right Leaf

	public List<GameObject>			birdTrac;
	public List<GameObject>			nestTrac;
	public List<GameObject>			leafTrac;

	public Vector3					lPos;
	public Vector3					mPos;
	public Vector3					rPos;

	public bool						inPos;

	public Vector3					lMoveTo;
	public Vector3					mMoveTo;
	public Vector3					rMoveTo;

	public bool						left;
	public bool						middle;
	public bool						right;

	public float					moveSpeed = 5.0f;
	public int						timesRun = 0;
	

	//[TODO] Track how many times game has been guessed right
	//[TODO] Increase speed each time game has been guessed right

	// Use this for initialization
	void Start () {
		iTween.Init (lBird);
		iTween.Init (mBird);
		iTween.Init (rBird);

		birdTrac.Add(lBird);
		birdTrac.Add(mBird);
		birdTrac.Add(rBird);

		nestTrac.Add(lNest);
		nestTrac.Add (mNest);
		nestTrac.Add (rNest);

		leafTrac.Add (lLeaf);
		leafTrac.Add (mLeaf);
		leafTrac.Add (rLeaf);

		lPos = lBird.transform.position;
		mPos = mBird.transform.position;
		rPos = rBird.transform.position;

		RunTheGame ();
	}
	
	// Update is called once per frame
	void Update () {

		//[TODO] Check that everything is back in place
		if(left){
			if(lBird.transform.position == lPos){
				inPos = true;
			}
		}
		if(middle){
			if(mBird.transform.position == mPos){
				inPos = true;
			}
		}
		if(right){
			if(rBird.transform.position == rPos){
				inPos = true;
			}
		}
		//[TODO] Cycle objects poping up
		
		if(timesRun < 3){
			if(inPos){
				RunTheGame ();
			}
		}
	}

	void RunTheGame(){

		//[X] Randomly select which between leaf and bird
		int n = (int)Random.Range(0,3);
		Debug.Log ("Number is " + n);

		//[X] Bird pops up and returns to nest
		//[X] Only one bird pops up at a time
		if(n == 0){ //Baby Bird on Left
			iTween.MoveFrom(birdTrac[0], iTween.Hash("y", 0.33f, "time", moveSpeed));
			iTween.MoveFrom(leafTrac[1], iTween.Hash("y", 0.33f, "time", moveSpeed));
			iTween.MoveFrom(leafTrac[2], iTween.Hash("y", 0.33f, "time", moveSpeed));

			//Track which nest bird last poped out of
			left = true;
			middle = false;
			right = false;
			Debug.Log ("Bird on Left");
			inPos = false;
		}
		if(n == 1){ //Baby Bird in Middle
			iTween.MoveFrom(birdTrac[1], iTween.Hash("y", 0.33f, "time", moveSpeed));
			iTween.MoveFrom(leafTrac[0], iTween.Hash("y", 0.33f, "time", moveSpeed));
			iTween.MoveFrom(leafTrac[2], iTween.Hash("y", 0.33f, "time", moveSpeed));

			//Track which nest bird last poped out of
			left = false;
			middle = true;
			right = false;
			Debug.Log ("Bird on Middle");
			inPos = false;
		}
		if(n == 2){ //Baby Bird on Right
			iTween.MoveFrom(birdTrac[2], iTween.Hash("y", 0.33f, "time", moveSpeed));
			iTween.MoveFrom(leafTrac[0], iTween.Hash("y", 0.33f, "time", moveSpeed));
			iTween.MoveFrom(leafTrac[1], iTween.Hash("y", 0.33f, "time", moveSpeed));

			//Track which nest bird last poped out of
			left = false;
			middle = false;
			right = true;
			Debug.Log ("Bird on Right");
			inPos = false;
		}
		timesRun++;
	}
}
