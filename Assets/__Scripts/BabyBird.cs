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

	public List<GameObject>			birdTrac; //List of birds
	public List<GameObject>			nestTrac; //List of nests
	public List<GameObject>			leafTrac; //List of leaves

	//Starting positions of birds
	public Vector3					lPos;
	public Vector3					mPos;
	public Vector3					rPos;

	public bool						inPos; //Has bird returned to starting position

	//Currently unused
	public Vector3					lMoveTo;
	public Vector3					mMoveTo;
	public Vector3					rMoveTo;

	public bool						left; //Is bird on left
	public bool						middle; //Is bird in middle
	public bool						right; //Is bird on right

	public float					moveSpeed = 5.0f; //Speed that bird returns to nest
	public int						timesRun = 0; //How many times has bird popped up
	public int						maxRuns = 3; //How many times should bird pop up

	//If players are active or eliminated
	public bool						player1 = true;
	public bool						player2 = true;
	public bool						player3 = true;
	public bool						player4 = true;

	public bool						makeAChoice = false; //Begins player selecetion process

	//Positions for player selection icons to move to
	public Vector3					select1;
	public Vector3					select2;
	public Vector3					select3;

	//Selection UI
	public GameObject				selections;

	//Player Selection Icons
	public GameObject				p1Icon;
	public GameObject				p2Icon;
	public GameObject				p3Icon;
	public GameObject				p4Icon;

	public float					timer = Mathf.Clamp (5,0,5);
	public bool						runTimer = false;

	public TextMesh					timerText;

	private int						p1Move = Mathf.Clamp (0,-1,1);
	private int						p2Move = Mathf.Clamp (0,-1,1);
	private int						p3Move = Mathf.Clamp (0,-1,1);
	private int						p4Move = Mathf.Clamp (0,-1,1);

	public bool						p1Selected = false;
	public bool						p2Selected = false;
	public bool						p3Selected = false;
	public bool						p4Selected = false;

	//[TODO] Track how many times game has been guessed right


	// Use this for initialization
	void Start () {
		iTween.Init (lBird);
		iTween.Init (mBird);
		iTween.Init (rBird);

		iTween.Init (selections);
		iTween.Init (p1Icon);
		iTween.Init (p2Icon);
		iTween.Init (p3Icon);
		iTween.Init (p4Icon);

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

		if(runTimer){
			timer -= 1 * Time.deltaTime;

			timerText.text = timer.ToString("0.00");
		}

		//Game Round Ends---------------
		if(timer <= 0 || p1Selected && p2Selected && p3Selected && p4Selected){
			CheckWork ();
		}//------------------------------


		//[X] Check that everything is back in place
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
		//[X] Cycle objects poping up
		
		if(timesRun < maxRuns){
			if(inPos){
				RunTheGame ();
			}
		}
		if(timesRun >= maxRuns){
			//[X] Players may make their selections
			Selection ();
		}

		//[TODO] Controls for player selection
		if(makeAChoice){

			//------------------- Player 1 ------------------
			if(!p1Selected){ //If player has made a selection input is no longer accepted
				if(Input.GetKeyDown(KeyCode.A)){ //Left
					p1Move--;
				}
				if(Input.GetKeyDown (KeyCode.S)){ //Select
					p1Selected = true;
					//[TODO] Audio for selection
				}
				if(Input.GetKeyDown (KeyCode.D)){ //Right
					p1Move++;
				}
			}
			//-----------------------------------------------

			//------------------- Player 2 -------------------
			if(!p2Selected){ //If player has selected input is no longer accepted
				if(Input.GetKeyDown (KeyCode.T)){ //Left
					p2Move--;
				}
				if(Input.GetKeyDown (KeyCode.Y)){ //Select
					p2Selected = true;
					//[TODO] Audio for selection
				}
				if(Input.GetKeyDown (KeyCode.U)){ //Right
					p2Move++;
				}
			}
			//------------------------------------------------

			//----------------- Player 3 ---------------------
			if(!p3Selected){ //If player has selected input is no longer accepted
				if(Input.GetKeyDown (KeyCode.V)){ //Left
					p3Move--;
				}
				if(Input.GetKeyDown (KeyCode.B)){ //Select
					p3Selected = true;
					//[TODO] Audio for selection
				}
				if(Input.GetKeyDown (KeyCode.M)){ //Right
					p3Move++;
				}
			}
			//------------------------------------------------

			//----------------- Player 4 ---------------------
			if(!p4Selected){ //If player has selected input is no longer accepted
				if(Input.GetKeyDown (KeyCode.LeftArrow)){ //Left
					p4Move--;
				}
				if(Input.GetKeyDown (KeyCode.DownArrow)){ //Select
					p4Selected = true;
					//[TODO] Audio for selection
				}
				if(Input.GetKeyDown (KeyCode.RightArrow)){ //Right
					p4Move++;
				}
			}
			//------------------------------------------------
	
		//----------------------Actually Moving the Selections------------------------
			//-----------------------------Move Left----------------------------
			if(p1Move == -1){
				iTween.MoveTo (p1Icon, iTween.Hash ("x", select1.x - 1.23f, "time", 0.25f));
			}
			if(p2Move == -1){
				iTween.MoveTo (p2Icon, iTween.Hash ("x", select1.x - 0.1f, "time", 0.25f));
			}
			if(p3Move == -1){
				iTween.MoveTo (p3Icon, iTween.Hash ("x", select1.x + 0.96f, "time", 0.25f));
			}
			if(p4Move == -1){
				iTween.MoveTo (p4Icon, iTween.Hash ("x", select1.x + 2, "time", 0.25f));
			}
			//-----------------------------Move Center---------------------------
			if(p1Move == 0){
				iTween.MoveTo (p1Icon, iTween.Hash ("x", select2.x - 1.23f, "time", 0.25f));
			}
			if(p2Move == 0){
				iTween.MoveTo (p2Icon, iTween.Hash ("x", select2.x - 0.1f, "time", 0.25f));
			}
			if(p3Move == 0){
				iTween.MoveTo (p3Icon, iTween.Hash ("x", select2.x + 0.96f, "time", 0.25f));
			}
			if(p4Move == 0){
				iTween.MoveTo (p4Icon, iTween.Hash ("x", select2.x + 2, "time", 0.25f));
			}
			//------------------------------Move Right----------------------------
			if(p1Move == 1){
				iTween.MoveTo (p1Icon, iTween.Hash ("x", select3.x - 1.23f, "time", 0.25f));
			}
			if(p2Move == 1){
				iTween.MoveTo (p2Icon, iTween.Hash ("x", select3.x - 0.1f, "time", 0.25f));
			}
			if(p3Move == 1){
				iTween.MoveTo (p3Icon, iTween.Hash ("x", select3.x + 0.96f, "time", 0.25f));
			}
			if(p4Move == 1){
				iTween.MoveTo (p4Icon, iTween.Hash ("x", select3.x + 2, "time", 0.25f));
			}
		} //End MakeChoice----------------------------------------------------------------------------
	}

	void RunTheGame(){

		//Move selection Menu
		iTween.MoveTo(selections, iTween.Hash ("y", -11.0f, "time", 0));

		//[X] Randomly select which between leaf and bird
		int n = (int)Random.Range(0,3);
		Debug.Log ("Number is " + n);

		//[X] Bird pops up and returns to nest
		//[X] Only one bird pops up at a time
		if(n == 0){ //Baby Bird on Left
			iTween.MoveFrom(birdTrac[0], iTween.Hash("y", 0.33f, "easetype", "easeInQuint", "time", moveSpeed));
			iTween.MoveFrom(leafTrac[1], iTween.Hash("y", 0.33f, "easetype", "easeInQuint", "time", moveSpeed));
			iTween.MoveFrom(leafTrac[2], iTween.Hash("y", 0.33f, "easetype", "easeInQuint", "time", moveSpeed));

			//Track which nest bird last poped out of
			left = true;
			middle = false;
			right = false;
			Debug.Log ("Bird on Left");
			inPos = false;
		}
		if(n == 1){ //Baby Bird in Middle
			iTween.MoveFrom(birdTrac[1], iTween.Hash("y", 0.33f, "easetype", "easeInQuint", "time", moveSpeed));
			iTween.MoveFrom(leafTrac[0], iTween.Hash("y", 0.33f, "easetype", "easeInQuint", "time", moveSpeed));
			iTween.MoveFrom(leafTrac[2], iTween.Hash("y", 0.33f, "easetype", "easeInQuint", "time", moveSpeed));

			//Track which nest bird last poped out of
			left = false;
			middle = true;
			right = false;
			Debug.Log ("Bird in Middle");
			inPos = false;
		}
		if(n == 2){ //Baby Bird on Right
			iTween.MoveFrom(birdTrac[2], iTween.Hash("y", 0.33f, "easetype", "easeInQuint", "time", moveSpeed));
			iTween.MoveFrom(leafTrac[0], iTween.Hash("y", 0.33f, "easetype", "easeInQuint", "time", moveSpeed));
			iTween.MoveFrom(leafTrac[1], iTween.Hash("y", 0.33f, "easetype", "easeInQuint", "time", moveSpeed));

			//Track which nest bird last poped out of
			left = false;
			middle = false;
			right = true;
			Debug.Log ("Bird on Right");
			inPos = false;
		}
		timesRun++;
	}

	public void Selection(){ //Enters the selection phase

		select1 = GameObject.Find ("Left-Select").transform.position;
		select2 = GameObject.Find ("Middle-Select").transform.position;
		select3 = GameObject.Find ("Right-Select").transform.position;

		iTween.MoveTo (selections, iTween.Hash("position", Vector3.zero, "time", 0.5f));

		makeAChoice = true;

		p1Selected = false;
		p2Selected = false;
		p3Selected = false;
		p4Selected = false;

		timesRun = 0;

		runTimer = true;
	}

	public void CheckWork(){ //Checks who guessed correctly or incorrectly
		Debug.Log ("Checking to see who guessed right");
		runTimer = false;
		timer = Mathf.Clamp (5,0,5);

		//[TODO] Increase speed each time game has been guessed

	}
}
