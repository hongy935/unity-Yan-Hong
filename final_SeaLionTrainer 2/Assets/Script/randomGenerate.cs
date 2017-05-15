using UnityEngine;
using System.Collections;

public class randomGenerate : MonoBehaviour {

	public int[] actionsQuest;
	public bool giveQuest=false;
	public int questLength=0;
	public bool exam=false;
	public float examTimer=10f;

	public static bool left = false;
	public static bool stay = true;
	public static bool right=false;

	public static bool shake =false;
	public static bool jump=false;
	public static bool clap=false;


	public int leftCounter = 0;
	public int rightCounter = 0;
	public int jumpCounter = 0;
	public int clapCounter = 0;
	public int shakeCounter = 0;

	bool isCleared=false;

	public static bool fail=false;
	public bool pass0 = false;
	public bool pass1=false;
	public bool pass2=false;
	public bool pass3=false;
	public bool pass4=false;
	public bool pass5=false;

	float moveHorizontal, moveVertical;
	public float speed;

	public Animator myAnimator;

	public GameObject shake1;
	public GameObject shake2;
	public GameObject shake3;
	public GameObject shake4;
	public GameObject shake5;
	public GameObject jump1;
	public GameObject jump2;
	public GameObject jump3;
	public GameObject jump4;
	public GameObject jump5;
	public GameObject clap1;
	public GameObject clap2;
	public GameObject clap3;
	public GameObject clap4;
	public GameObject clap5;


	Rigidbody rb;

	public bool timeStart=false;

	public GameObject timerObject;
	TextMesh time;

	public static bool iceTime=false;

	public GameObject bubble1;
	public GameObject bubble2;
	public GameObject bubble3;


	public static bool waitForStart=true;

	public GameObject great;
	public GameObject lose;
	public GameObject wait;
	public GameObject scoreDisplay;

	public GameObject dontDestroy; 

	int score=0;

	public static bool clapToRestart = false;

	public GameObject audioCenter;

	AudioSource[] audio; 

	float delayTimer=1f; 
	const float delay = 1f;
	 bool delay1Ends=false;
	bool delay2Ends=false;
	bool delay3Ends=false;
	bool delay4Ends=false;

	bool flag1=false;
	bool flag2=false;
	bool flag3=false;
	bool flag4=false;
	bool flag5=false;
	

	void Awake(){
		DontDestroyOnLoad (dontDestroy);
	}

	void Start () {
		score = 0;
		rb = GetComponent<Rigidbody> ();
		time = timerObject.GetComponent<TextMesh> ();

		jump1.GetComponent<Renderer>().enabled = false;
		shake1.GetComponent<Renderer>().enabled = false;
		clap1.GetComponent<Renderer>().enabled = false;
		jump2.GetComponent<Renderer>().enabled = false;
		shake2.GetComponent<Renderer>().enabled = false;
		clap2.GetComponent<Renderer>().enabled = false;
		jump3.GetComponent<Renderer>().enabled = false;
		shake3.GetComponent<Renderer>().enabled = false;
		clap3.GetComponent<Renderer>().enabled = false;
		jump4.GetComponent<Renderer>().enabled = false;
		shake4.GetComponent<Renderer>().enabled = false;
		clap4.GetComponent<Renderer>().enabled = false;
		jump5.GetComponent<Renderer>().enabled = false;
		shake5.GetComponent<Renderer>().enabled = false;
		clap5.GetComponent<Renderer>().enabled = false;
		bubble1.GetComponent<SpriteRenderer>().enabled = false;
		bubble2.GetComponent<SpriteRenderer>().enabled = false;
		bubble3.GetComponent<SpriteRenderer>().enabled = false;

		great.GetComponent<MeshRenderer> ().enabled = false;
		lose.GetComponent<MeshRenderer> ().enabled = false;

		wait.GetComponent<MeshRenderer> ().enabled = false;

		waitForStart = true;

		audio = audioCenter.GetComponents<AudioSource> ();

	}


	void Update () {


		
		covertIncoming ();

		//animation controller
		animationController ();

		score = DestroyIce.score;
		scoreDisplay.GetComponent<TextMesh> ().text = score+" ";

		//Debug.Log (waitForStart);


		if (waitForStart&&clap) {
			wait.GetComponent<MeshRenderer> ().enabled = false;
			giveQuest = true;
			generateNum ();

		}



		if (clapToRestart) {

			lose.GetComponent<MeshRenderer> ().enabled = true;
			audio [8].Play ();

			if (clap) {
				lose.GetComponent<MeshRenderer> ().enabled = false;
				//BootOrIcecream.bootTimer = 6;
				//BootOrIcecream.iceTimer = 6;
				clapToRestart = false;
				BootOrIcecream.restartCurrentScene ();

			}


		}


			
			if (pass5) {
			audio [1].Play ();
				exam = false;
			iceTime = true; 

			great.GetComponent<MeshRenderer> ().enabled = true;

				//success 
				// play sea lion happy animation
				// sea lion correct bubble
				// trigger to drop ice cream
			}

			if (!exam) {
				//reset
				pass1 = false;
				pass2 = false;
				pass3 = false;
				pass4 = false;
				pass5 = false;
			
				
			}

		if (timeStart) {
			examTimer -= Time.deltaTime;
			time.text=(int)examTimer+"''";


		}

			if (examTimer < 0) {
				exam = false;
				fail = true;
			examTimer = 0;
				//fail
			}

		if (iceTime) {
			timeStart = false;
			jump1.GetComponent<Renderer>().enabled = false;
			shake1.GetComponent<Renderer>().enabled = false;
			clap1.GetComponent<Renderer>().enabled = false;
			jump2.GetComponent<Renderer>().enabled = false;
			shake2.GetComponent<Renderer>().enabled = false;
			clap2.GetComponent<Renderer>().enabled = false;
			jump3.GetComponent<Renderer>().enabled = false;
			shake3.GetComponent<Renderer>().enabled = false;
			clap3.GetComponent<Renderer>().enabled = false;
			jump4.GetComponent<Renderer>().enabled = false;
			shake4.GetComponent<Renderer>().enabled = false;
			clap4.GetComponent<Renderer>().enabled = false;
			jump5.GetComponent<Renderer>().enabled = false;
			shake5.GetComponent<Renderer>().enabled = false;
			clap5.GetComponent<Renderer>().enabled = false;

			bubble1.GetComponent<Renderer>().enabled = false;
			bubble2.GetComponent<Renderer>().enabled = false;
			bubble3.GetComponent<Renderer>().enabled = false;
		}

		if (fail) {
			examTimer = 5f;
			jump1.GetComponent<Renderer>().enabled = false;
			shake1.GetComponent<Renderer>().enabled = false;
			clap1.GetComponent<Renderer>().enabled = false;
			jump2.GetComponent<Renderer>().enabled = false;
			shake2.GetComponent<Renderer>().enabled = false;
			clap2.GetComponent<Renderer>().enabled = false;
			jump3.GetComponent<Renderer>().enabled = false;
			shake3.GetComponent<Renderer>().enabled = false;
			clap3.GetComponent<Renderer>().enabled = false;
			jump4.GetComponent<Renderer>().enabled = false;
			shake4.GetComponent<Renderer>().enabled = false;
			clap4.GetComponent<Renderer>().enabled = false;
			jump5.GetComponent<Renderer>().enabled = false;
			shake5.GetComponent<Renderer>().enabled = false;
			clap5.GetComponent<Renderer>().enabled = false;

			bubble1.GetComponent<Renderer>().enabled = false;
			bubble2.GetComponent<Renderer>().enabled = false;
			bubble3.GetComponent<Renderer>().enabled = false;
		}
					// if fail, trigger to drop bootq	



		}

	//jump:1,shake:2,clap:3

	void generateNum(){

		Debug.Log ("GEN");
		
			if (giveQuest) {


			flag1 = false;
			flag2 = false;
			flag3 = false;
			flag4 = false;

			audio [2].Play ();
			bubble1.GetComponent<Renderer>().enabled = true;
			bubble2.GetComponent<Renderer>().enabled = true;
			bubble3.GetComponent<Renderer>().enabled = true;
			actionsQuest = new int[5];
			for (int i = 0; i < 5; i++) {
				actionsQuest[i]= (int)Random.Range (1f, 3.5f);
				//Debug.Log (actionsQuest[i]);
			}
			//show the quest in pics

			//show the quest in pics
			if(actionsQuest[0]==1){
				jump1.GetComponent<Renderer>().enabled = true;
				shake1.GetComponent<Renderer>().enabled = false;
				clap1.GetComponent<Renderer>().enabled = false;
			}
			if(actionsQuest[0]==2){
				jump1.GetComponent<Renderer>().enabled = false;
				shake1.GetComponent<Renderer>().enabled = true;
				clap1.GetComponent<Renderer>().enabled = false;
			}
			if(actionsQuest[0]==3){
				jump1.GetComponent<Renderer>().enabled = false;
				shake1.GetComponent<Renderer>().enabled = false;
				clap1.GetComponent<Renderer>().enabled = true;
			}

			if(actionsQuest[1]==1){
				jump2.GetComponent<Renderer>().enabled = true;
				shake2.GetComponent<Renderer>().enabled = false;
				clap2.GetComponent<Renderer>().enabled = false;
			}
			if(actionsQuest[1]==2){
				jump2.GetComponent<Renderer>().enabled = false;
				shake2.GetComponent<Renderer>().enabled = true;
				clap2.GetComponent<Renderer>().enabled = false;
			}
			if(actionsQuest[1]==3){
				jump2.GetComponent<Renderer>().enabled = false;
				shake2.GetComponent<Renderer>().enabled = false;
				clap2.GetComponent<Renderer>().enabled = true;
			}

			if(actionsQuest[2]==1){
				jump3.GetComponent<Renderer>().enabled = true;
				shake3.GetComponent<Renderer>().enabled = false;
				clap3.GetComponent<Renderer>().enabled = false;
			}
			if(actionsQuest[2]==2){
				jump3.GetComponent<Renderer>().enabled = false;
				shake3.GetComponent<Renderer>().enabled = true;
				clap3.GetComponent<Renderer>().enabled = false;
			}
			if(actionsQuest[2]==3){
				jump3.GetComponent<Renderer>().enabled = false;
				shake3.GetComponent<Renderer>().enabled = false;
				clap3.GetComponent<Renderer>().enabled = true;
			}

			if(actionsQuest[3]==1){
				jump4.GetComponent<Renderer>().enabled = true;
				shake4.GetComponent<Renderer>().enabled = false;
				clap4.GetComponent<Renderer>().enabled = false;
			}
			if(actionsQuest[3]==2){
				jump4.GetComponent<Renderer>().enabled = false;
				shake4.GetComponent<Renderer>().enabled = true;
				clap4.GetComponent<Renderer>().enabled = false;
			}
			if(actionsQuest[3]==3){
				jump4.GetComponent<Renderer>().enabled = false;
				shake4.GetComponent<Renderer>().enabled = false;
				clap4.GetComponent<Renderer>().enabled = true;
			}

			if(actionsQuest[4]==1){
				jump5.GetComponent<Renderer>().enabled = true;
				shake5.GetComponent<Renderer>().enabled = false;
				clap5.GetComponent<Renderer>().enabled = false;
			}
			if(actionsQuest[4]==2){
				jump5.GetComponent<Renderer>().enabled = false;
				shake5.GetComponent<Renderer>().enabled = true;
				clap5.GetComponent<Renderer>().enabled = false;
			}
			if(actionsQuest[4]==3){
				jump5.GetComponent<Renderer>().enabled = false;
				shake5.GetComponent<Renderer>().enabled = false;
				clap5.GetComponent<Renderer>().enabled = true;
			}
			//reset
			BootOrIcecream.bootTimer=6;
			BootOrIcecream.iceTimer = 6;


			exam = true; 
			timeStart = true;
			fail = false;
			isCleared = false;

			giveQuest = false; 
			examTimer = 5f;
			waitForStart = false;

			}



		}


	

	void animationController (){

		if (left) {
			//move player to left
			moveHorizontal = -1f;
			Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

			rb.AddForce (movement * speed);

			//Debug.Log ("left");
		}

		if (right) {
			//move player to right
			moveHorizontal = 1f;
			Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

			rb.AddForce (movement * speed);
			//Debug.Log ("right");
		}

		if (stay) {
			//stop moving
			moveHorizontal = 0;
		}





		if (jump) {
			if (fail) {
				Debug.Log ("FAIL");
			}

			jumpCounter++;
			//play jump animation & move player up
			myAnimator.SetBool ("Jump_A", true);

			if (exam) {
				//examTimer -= Time.deltaTime;
				if (!isCleared) {
					pass1 = false;
					pass2 = false;
					pass3 = false;
					pass4 = false;
					pass5 = false;
					isCleared = true;
				}

				//float delayALittle = 1f;
				//delayALittle -= Time.deltaTime;
				//if (delayALittle < 0) {
				//	pass0 = true;
				//}


				if (!pass1) {
					if (actionsQuest [0] == 1) {
						if (jump&&!flag1) {
							pass1 = true;
							jump1.GetComponent<Renderer>().enabled = false;

							audio [5].Play();
							delayTimer = Time.time;
							flag1 = true;
							Debug.Log ("pass1");
						} else {
							//exam = false;
							//fail = true;
							//Debug.Log ("pass1");

							//fail
						}
					}

					if (actionsQuest [0] == 2) {
						if (shake&&!flag1) {
							pass1 = true;
							shake1.GetComponent<Renderer>().enabled = false;
							audio [5].Play();
							Debug.Log ("pass1");
							delayTimer = Time.time;
							flag1 = true;
						} else {
							//exam = false;
							//fail = true;

							//fail
						}

					}
					if (actionsQuest [0] == 3) {
						if (clap&&!flag1) {
							pass1 = true;
							clap1.GetComponent<Renderer>().enabled = false;
							audio [5].Play();
							Debug.Log ("pass1");
							delayTimer = Time.time;
							flag1 = true;
						} else {
							//exam = false;
							//fail = true;

							//fail
						}
					}

					if(Time.time-delayTimer>delay) {
						delay1Ends = true;
					}
				}


				///////first action


					

				if (pass1&&!pass2&&delay1Ends) {

					if (actionsQuest [1] == 1) {
						if (jump&&!flag2) {
							pass2 = true;
							jump2.GetComponent<Renderer>().enabled = false;
							audio [5].Play();
							Debug.Log ("pass2");
							delayTimer = Time.time;
							flag2 = true;
						} else {
							//exam = false;
							//fail = true;

							//fail
						}
					}

					if (actionsQuest [1] == 2) {
						if (shake&&!flag2) {
							pass2 = true;
							shake2.GetComponent<Renderer>().enabled = false;
							audio [5].Play();
							Debug.Log ("pass2");
							delayTimer = Time.time;
							flag2 = true;

						} else {
							//exam = false;
							//fail = true;

							//fail
						}

					}
					if (actionsQuest [1] == 3) {
						if (clap&&!flag2) {
							pass2 = true;
							clap2.GetComponent<Renderer>().enabled = false;
							audio [5].Play();
							Debug.Log ("pass2");
							delayTimer = Time.time;
							flag2 = true;

						} else {
							//exam = false;
							///fail = true;

							//fail
						}
					}

					if(Time.time-delayTimer>delay) {
						delay2Ends = true;
					}
				}

				///////// second action
				/// 
		


				if (pass2&&!pass3&&delay2Ends) {

					if (actionsQuest [2] == 1) {
						if (jump&&!flag3) {
							pass3 = true;
							jump3.GetComponent<Renderer>().enabled = false;
							audio [5].Play();
							Debug.Log ("pass3");
							delayTimer = Time.time;
							flag3 = true;
						} else {
							//exam = false;
							//fail = true;

							//fail
						}
					}

					if (actionsQuest [2] == 2) {
						if (shake&&!flag3) {
							pass3 = true;
							shake3.GetComponent<Renderer>().enabled = false;
							audio [5].Play();
							Debug.Log ("pass3");
							delayTimer = Time.time;
							flag3 = true;
						} else {
							//exam = false;
							//fail = true;

							//fail
						}

					}
					if (actionsQuest [2] == 3) {
						if (clap&&!flag3) {
							pass3 = true;
							shake3.GetComponent<Renderer>().enabled = false;
							audio [5].Play();
							Debug.Log ("pass3");
							delayTimer = Time.time;
							flag3 = true;
						} else {
							//exam = false;
							//fail = true;

							//fail
						}
					}
					if(Time.time-delayTimer>delay) {
						delay3Ends = true;
					}
				}
				/////// third action

				if (pass3&&!pass4&&delay3Ends) {

					if (actionsQuest [3] == 1) {
						if (jump&&!flag4) {
							pass4 = true;
							jump4.GetComponent<Renderer>().enabled = false;
							audio [5].Play();
							Debug.Log ("pass4");
							flag4 = true;
						} else {
							//exam = false;
							//fail = true;

							//fail
						}
					}

					if (actionsQuest [3] == 2) {
						if (shake&&!flag4) {
							pass4 = true;
							shake4.GetComponent<Renderer>().enabled = false;
							audio [5].Play();
							Debug.Log ("pass4");
							flag4 = true;
						} else {
							//exam = false;
							//fail = true;

							//fail
						}

					}
					if (actionsQuest [3] == 3) {
						if (clap) {
							pass4 = true;
							clap4.GetComponent<Renderer>().enabled = false;
							audio [5].Play();
							Debug.Log ("pass4");
						} else {
							//exam = false;
							//fail = true;

							//fail
						}
					}
					if(Time.time-delayTimer>delay) {
						delay4Ends = true;
					}
				}
				//////////// forth action


				if (pass4&&!pass5) {

					if (actionsQuest [4] == 1) {
						if (jump&&!flag5) {
							pass5 = true;
							jump5.GetComponent<Renderer>().enabled = false;
							audio [5].Play();
							Debug.Log ("pass5");
							flag5 = true;
						} else {
							//exam = false;
							//fail = true;

							//fail
						}
					}

					if (actionsQuest [4] == 2) {
						if (shake&&!flag5) {
							pass5 = true;
							shake5.GetComponent<Renderer>().enabled = false;
							audio [5].Play();
							Debug.Log ("pass5");
							flag5 = true;
						} else {
							//exam = false;
							//fail = true;

							//fail
						}

					}
					if (actionsQuest [4] == 3) {
						if (clap&&!flag5) {
							pass5 = true;
							clap5.GetComponent<Renderer>().enabled = false;
							audio [5].Play();
							Debug.Log ("pass5");
							flag5 = true;
						} else {
							//exam = false;
							//fail = true;

							//fail
						}
					}

				}

		}
		} else {
				myAnimator.SetBool ("Jump_A", false);
			audio [3].Play ();
			}


		//////////////////

		if (clap) {
			if (fail) {
				Debug.Log ("FAIL");
			}

			//play clap animation
			clapCounter++;
			myAnimator.SetBool ("Clap_A", true);
			if (exam) {
				//examTimer -= Time.deltaTime;
				if (!isCleared) {
					leftCounter = 0;
					rightCounter = 0;
					jumpCounter = 0;
					clapCounter = 0;
					shakeCounter = 0;
					isCleared = true;
				}

				if (!pass1) {
					if (actionsQuest [0] == 1) {
						if (jump&&!flag1) {
							pass1 = true;
							jump1.GetComponent<Renderer>().enabled = false;
							audio [5].Play();
							Debug.Log ("pass1");
							flag1 = true;
						} else {
							//exam = false;
							//fail = true;
							//Debug.Log ("pass1");

							//fail
						}
					}

					if (actionsQuest [0] == 2) {
						if (shake&&!flag1) {
							pass1 = true;
							shake1.GetComponent<Renderer>().enabled = false;
							audio [5].Play();
							Debug.Log ("pass1");
							flag1 = true;
						} else {
							//exam = false;
							//fail = true;

							//fail
						}

					}
					if (actionsQuest [0] == 3) {
						if (clap&&flag1) {
							pass1 = true;
							clap1.GetComponent<Renderer>().enabled = false;
							audio [5].Play();
							Debug.Log ("pass1");
							flag1 = true;
						} else {
							//exam = false;
							//fail = true;

							//fail
						}
					}
					if(Time.time-delayTimer>delay) {
						delay1Ends = true;
					}
				}
				///////first action

				if (pass1&&!pass2&&delay1Ends) {

					if (actionsQuest [1] == 1) {
						if (jump&&!flag2) {
							pass2 = true;
							jump2.GetComponent<Renderer>().enabled = false;
							audio [5].Play();
							Debug.Log ("pass2");
							flag2 = true;
						} else {
							//exam = false;
							//fail = true;

							//fail
						}
					}

					if (actionsQuest [1] == 2) {
						if (shake&&!flag2) {
							pass2 = true;
							shake2.GetComponent<Renderer>().enabled = false;
							audio [5].Play();
							Debug.Log ("pass2");
							flag2 = true;
						} else {
							//exam = false;
							//fail = true;

							//fail
						}

					}
					if (actionsQuest [1] == 3) {
						if (clap&&!flag2) {
							pass2 = true;
							clap2.GetComponent<Renderer>().enabled = false;
							audio [5].Play();
							Debug.Log ("pass2");
							flag2 = true;
						} else {
							//exam = false;
							//fail = true;

							//fail
						}
					}
					if(Time.time-delayTimer>delay) {
						delay2Ends = true;
					}
				}
				///////// second action

				if (pass2&&!pass3&&delay2Ends) {

					if (actionsQuest [2] == 1) {
						if (jump&&!flag3) {
							pass3 = true;
							jump3.GetComponent<Renderer>().enabled = false;
							audio [5].Play();
							Debug.Log ("pass3");
							flag3 = true;
						} else {
							//exam = false;
							//fail = true;

							//fail
						}
					}

					if (actionsQuest [2] == 2) {
						if (shake&&!flag3) {
							pass3 = true;
							shake3.GetComponent<Renderer>().enabled = false;
							audio [5].Play();
							Debug.Log ("pass3");
							flag3 = true;
						} else {
							//exam = false;
							//fail = true;

							//fail
						}

					}
					if (actionsQuest [2] == 3) {
						if (clap&&!flag3) {
							pass3 = true;
							clap3.GetComponent<Renderer>().enabled = false;
							audio [5].Play();
							Debug.Log ("pass3");
							flag3 = true;
						} else {
							//exam = false;
							//fail = true;

							//fail
						}
					}
					if(Time.time-delayTimer>delay) {
						delay3Ends = true;
					}
				}
				/////// third action

				if (pass3&&!pass4&&delay3Ends) {

					if (actionsQuest [3] == 1) {
						if (jump&&!flag4) {
							pass4 = true;
							jump4.GetComponent<Renderer>().enabled = false;
							audio [5].Play();
							Debug.Log ("pass4");
							flag4 = true;
						} else {
							//exam = false;
							//fail = true;

							//fail
						}
					}

					if (actionsQuest [3] == 2) {
						if (shake&&!flag4) {
							pass4 = true;
							shake4.GetComponent<Renderer>().enabled = false;
							audio [5].Play();
							Debug.Log ("pass4");
							flag4 = true;
						} else {
							//exam = false;
							//fail = true;

							//fail
						}

					}
					if (actionsQuest [3] == 3) {
						if (clap&&!flag4) {
							pass4 = true;
							clap4.GetComponent<Renderer>().enabled = false;
							audio [5].Play();
							Debug.Log ("pass4");
							flag4 = true;
						} else {
							//exam = false;
							//fail = true;

							//fail
						}
					}
					if(Time.time-delayTimer>delay) {
						delay4Ends = true;
					}
				}
				//////////// forth action


				if (pass4&&!pass5&&delay4Ends) {

					if (actionsQuest [4] == 1) {
						if (jump&&!flag5) {
							pass5 = true;
							jump5.GetComponent<Renderer>().enabled = false;
							audio [5].Play();
							Debug.Log ("pass5");
							flag5 = true;
						} else {
							//exam = false;
							//fail = true;

							//fail
						}
					}

					if (actionsQuest [4] == 2) {
						if (shake&&!flag5) {
							pass5 = true;
							shake5.GetComponent<Renderer>().enabled = false;
							audio [5].Play();
							Debug.Log ("pass5");
							flag5 = true;
						} else {
							//exam = false;
							//fail = true;

							//fail
						}

					}
					if (actionsQuest [4] == 3) {
						if (clap&&!flag5) {
							pass5 = true;
							clap5.GetComponent<Renderer>().enabled = false;
							audio [5].Play();
							Debug.Log ("pass5");
							flag5 = true;
						} else {
							//exam = false;
							//fail = true;

							//fail
						}
					}


				}

			}
		}else {
					myAnimator.SetBool ("Clap_A", false);
			audio [4].Play ();
				}

		//////////////////

				if (shake) {
			if (fail) {
				Debug.Log ("FAIL");
			}

					//play shake animation
					shakeCounter++;
					myAnimator.SetBool ("Shake_A", true);
					if (exam) {
						//examTimer -= Time.deltaTime;
						if (!isCleared) {
							leftCounter = 0;
							rightCounter = 0;
							jumpCounter = 0;
							clapCounter = 0;
							shakeCounter = 0;
							isCleared = true;
						}

				if (!pass1) {

					if (actionsQuest [0] == 1) {
						if (jump&&!flag1) {
							pass1 = true;
							jump1.GetComponent<Renderer>().enabled = false;
							audio [5].Play();
							Debug.Log ("pass1");
							flag1 = true;
						} else {
							//exam = false;
							//fail = true;
							//Debug.Log ("pass1");

							//fail
						}
					}

					if (actionsQuest [0] == 2) {
						if (shake&&!flag1) {
							pass1 = true;
							shake1.GetComponent<Renderer>().enabled = false;
							audio [5].Play();
							Debug.Log ("pass1");
							flag1 = true;
						} else {
							//exam = false;
							//fail = true;

							//fail
						}

					}
					if (actionsQuest [0] == 3) {
						if (clap&&!flag1) {
							pass1 = true;
							clap1.GetComponent<Renderer>().enabled = false;
							audio [5].Play();
							Debug.Log ("pass1");
							flag1 = true;
						} else {
							//exam = false;
							//fail = true;

							//fail
						}

					}
					if(Time.time-delayTimer>delay) {
						delay1Ends = true;
					}
				}
						///////first action

				if (pass1&&!pass2&&delay1Ends) {

							if (actionsQuest [1] == 1) {
						if (jump&&!flag2) {
									pass2 = true;
							jump2.GetComponent<Renderer>().enabled = false;
							audio [5].Play();
									Debug.Log ("pass2");
							flag2 = true;
								} else {
									//exam = false;
									//fail = true;
									
									//fail
								}
							}

							if (actionsQuest [1] == 2) {
						if (shake&&!flag2) {
									pass2 = true;
							shake2.GetComponent<Renderer>().enabled = false;
							audio [5].Play();
									Debug.Log ("pass2");
							flag2 = true;
								} else {
									//exam = false;
									//fail = true;
									
									//fail
								}

							}
							if (actionsQuest [1] == 3) {
						if (clap&&!flag2) {
									pass2 = true;
							clap2.GetComponent<Renderer>().enabled = false;
							audio [5].Play();
									Debug.Log ("pass2");
							flag2 = true;
								} else {
									//exam = false;
									//fail = true;
									
									//fail
								}
							}
					if(Time.time-delayTimer>delay) {
						delay2Ends = true;
					}
						}
						///////// second action

				if (pass2&&!pass3&&delay2Ends) {

							if (actionsQuest [2] == 1) {
						if (jump&&!flag3) {
									pass3 = true;
							jump3.GetComponent<Renderer>().enabled = false;
							audio [5].Play();
									Debug.Log ("pass3");
							flag3 = true;
								} else {
									//exam = false;
									//fail = true;
									
									//fail
								}
							}

							if (actionsQuest [2] == 2) {
						if (shake&&!flag3) {
									pass3 = true;
							shake3.GetComponent<Renderer>().enabled = false;
							audio [5].Play();
									Debug.Log ("pass3");
							flag3 = true;
								} else {
									//exam = false;
									//fail = true;
									
									//fail
								}

							}
							if (actionsQuest [2] == 3) {
						if (clap&&!flag3) {
									pass3 = true;
							clap3.GetComponent<Renderer>().enabled = false;
							audio [5].Play();
									Debug.Log ("pass3");
							flag3 = true;
								} else {
									//exam = false;
									//fail = true;
									
									//fail
								}
							}
					if(Time.time-delayTimer>delay) {
						delay3Ends = true;
					}
						}
						/////// third action

				if (pass3&&!pass4&&delay3Ends) {

							if (actionsQuest [3] == 1) {
						if (jump&&!flag4) {
									pass4 = true;
							jump4.GetComponent<Renderer>().enabled = false;
							audio [5].Play();
									Debug.Log ("pass4");
							flag4 = true;
								} else {
									//exam = false;
									//fail = true;
									
									//fail
								}
							}

							if (actionsQuest [3] == 2) {
						if (shake&&!flag4) {
									pass4 = true;
							shake4.GetComponent<Renderer>().enabled = false;
							audio [5].Play();
									Debug.Log ("pass4");
							flag4 = true;
								} else {
									//exam = false;
									//fail = true;
									
									//fail
								}

							}
							if (actionsQuest [3] == 3) {
						if (clap&&!flag4) {
									pass4 = true;
							clap4.GetComponent<Renderer>().enabled = false;
							audio [5].Play();
									Debug.Log ("pass4");
							flag4 = true;
								} else {
									//exam = false;
									//fail = true;
									
									//fail
								}
							}
					if(Time.time-delayTimer>delay) {
						delay4Ends = true;
					}
						}
						//////////// forth action


				if (pass4&&!pass5&&delay4Ends) {

							if (actionsQuest [4] == 1) {
						if (jump&&flag5) {
									pass5 = true;
							jump5.GetComponent<Renderer>().enabled = false;
							audio [5].Play();
									Debug.Log ("pass5");

								} else {
									//exam = false;
									//fail = true;
									
									//fail
								}
							}

							if (actionsQuest [4] == 2) {
								if (shake) {
									pass5 = true;
							shake5.GetComponent<Renderer>().enabled = false;
							audio [5].Play();
									Debug.Log ("pass5");
								} else {
									//exam = false;
									//fail = true;
									
									//fail
								}

							}
							if (actionsQuest [4] == 3) {
								if (clap) {
									pass5 = true;
							clap5.GetComponent<Renderer>().enabled = false;
							audio [5].Play();
									Debug.Log ("pass5");
								} else {
									//exam = false;
									//fail = true;
									
									//fail
								}
							}
						}

					}
				} else {
					myAnimator.SetBool ("Shake_A", false);
			audio [7].Play();
				}
			
		}




		
	

	void covertIncoming(){
		//move horizontal
		if (BasicSerial.comingChunk [0] == 0) {
			stay = true;
			left = false;
			right = false;
		}

		if (BasicSerial.comingChunk [0] == 1) {
			stay = false;
			left = false;
			right = true;
		}

		if (BasicSerial.comingChunk [0] == -1) {
			stay = false;
			left = true;
			right = false;
		}

		//shake
		if (BasicSerial.comingChunk [1] == 0) {
			shake = false;
		}
		if (BasicSerial.comingChunk [1] == 1) {
			shake = true;
		}
	
		//jump
		if (BasicSerial.comingChunk [2] == 0) {
			jump = false;
		}
		if (BasicSerial.comingChunk [2] == 1) {
			jump = true;
		}


		//clap
		if (BasicSerial.comingChunk [3] == 0) {
			clap = false;
		}
		if (BasicSerial.comingChunk [3] == 1) {
			clap = true;
		}
	}

}
