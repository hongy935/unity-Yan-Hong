using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BootOrIcecream : MonoBehaviour {

	public GameObject prefabA;
	public GameObject prefabB;
	public GameObject playerA;
	public GameObject playerB;

	int counterBoot = 0;
	int counterIce = 0;

	public static float bootTimer=6;
	public static float iceTimer=6;

	public GameObject great;
	public GameObject lose;
	public GameObject wait;
	// Use this for initialization
	void Start () {

		StartCoroutine (BlinkTimer ());
		great.GetComponent<MeshRenderer> ().enabled = false;
		lose.GetComponent<MeshRenderer> ().enabled = false;

	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.R)) {
			restartCurrentScene ();
		}

		//Debug.Log ("boot "+bootTimer);
		//Debug.Log ("ice "+iceTimer);
		if (randomGenerate.fail) {
			bootTimer -= Time.deltaTime;
		}

		if (randomGenerate.iceTime) {
			iceTimer -= Time.deltaTime;
		}

		if (iceTimer < 0) {
			randomGenerate.iceTime = false;
			randomGenerate.waitForStart = true;
			counterIce = 0;
			wait.GetComponent<MeshRenderer> ().enabled = true;
		}

		if (bootTimer < 0) {
			counterBoot = 0;
			randomGenerate.waitForStart = true;
			randomGenerate.fail = false;

			if (!randomGenerate.clapToRestart) {
				
			
				wait.GetComponent<MeshRenderer> ().enabled = true;
			}
		}

	}

	public static void restartCurrentScene (){
		randomGenerate.waitForStart = true;
		randomGenerate.fail = false;
		DestroyIce.score = 0;
		int scene = SceneManager.GetActiveScene ().buildIndex;
		SceneManager.LoadScene (scene, LoadSceneMode.Single);

	}





	IEnumerator BlinkTimer()
	{
		yield return new WaitForSeconds (1);

		if (randomGenerate.fail) {

			if (bootTimer > 0) {
				
		        
				if (counterBoot < 6) {
//				float randonNumber = Random.Range (0f, 100f);
//				if (randonNumber < 50f) {
					GameObject newClone = (GameObject)Instantiate (prefabA, 
						                      new Vector3 (Random.Range (-150f, 150f), 100f, -65f),
						                      Quaternion.Euler (-34.6f, 90f, 0f)
					                      );
//				} 
				
				counterBoot++;
				} else {
					
				}

			}
		}


		if (randomGenerate.iceTime) {

			if (iceTimer > 0) {



				if (counterIce < 6) {
					GameObject newClone2 = (GameObject)Instantiate (prefabB, 
						                        new Vector3 (Random.Range (-150f, 150f), 100f, -65f),
						                        Quaternion.Euler (0f, 0f, 0f)
					                        );
					great.GetComponent<MeshRenderer> ().enabled = false;

					counterIce++;
				} else {
					
						
				}
			}
		}




		StartCoroutine (BlinkTimer ());

	}





	//{
	//	GameObject newClone2 = (GameObject)Instantiate (prefabB, 
	//		new Vector3 (Random.Range (-150f, 150f), 300f, 0f),
	//		Quaternion.Euler (0f, 0f, 0f)
	//	);
	//}
}
