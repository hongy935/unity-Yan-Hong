using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraRayCast : MonoBehaviour {
	[SerializeField]
	Camera mainCamera;
	[SerializeField]
	CharacterController m_CharacterController;

	[SerializeField]
	GameObject waterScaler;

	[SerializeField]
	Text Information;

	public bool isPlaying = false;


	// Use this for initialization
	float cookiesIndex = 0;
	float drinkIndex = 0, drinkLimition = 4;
	float proportion;
	//bool CanDrink = true;
	void Start () {
	
	}



	void Update(){
		Ray ray = new Ray(mainCamera.transform.position,mainCamera.transform.forward);
		RaycastHit hit;

		Debug.DrawRay (mainCamera.transform.position, mainCamera.transform.forward, Color.red);
		if (Physics.Raycast (ray, out hit)) {
		//	Debug.Log ("doing");
			if (hit.collider.tag == "drink") {
				Information.text = "Drink me!";
				if (Input.GetMouseButtonDown (0) && m_CharacterController.transform.localScale.y >0.2f) {
					drinkIndex++;
					proportion = (drinkLimition - drinkIndex) / drinkLimition;
					Debug.Log ("Hit");
					if (proportion >= 0) {
						//sound appear here
						SoundManager.instance.PlayMusic (0);
						if (proportion != 0) {
							LeanTween.scaleY (waterScaler, proportion, 1f);
						} else if (proportion == 0) {
							LeanTween.scaleY (waterScaler, proportion, 1f).setOnComplete (delegate() {
								LeanTween.scaleY (waterScaler, 1f, 1).setDelay (0).setOnComplete (delegate() {
									drinkIndex = 0;
								});
							});
						}
						if (m_CharacterController.transform.localScale.y >0.2f) {
							m_CharacterController.transform.localScale -= new Vector3 (0f, 0.2f, 0f);
						}
					}
				}
			} 

			if (hit.collider.tag == "Untagged")  {
				Information.text = " ";
			}


			if (hit.collider.tag == "radio")  {
				Information.text = "Radio";
				if (Input.GetMouseButtonDown (0)) {
					if (isPlaying == false) {
						SoundManager.instance.PlayMusic (2);
						isPlaying = true;
					} else {
						SoundManager.instance.StopMusic ();
						isPlaying = false;
					}
				} 
			}


			if (hit.collider.tag == "top")  {
				Information.text = " ";
				if (Input.GetMouseButtonDown (0)) {
					hit.collider.GetComponent<spin> ().isSpinning = !hit.collider.GetComponent<spin> ().isSpinning;
				}
			}

			if (hit.collider.tag == "cookie") {
				Information.text = "Eat me!";
				if (Input.GetMouseButtonDown (0) && cookiesIndex <= 3 && !hit.collider.GetComponent<Cookie> ().isEmpty) {
					//sound 
					SoundManager.instance.PlayMusic(1);
					Debug.Log ("Hit");
					StartCoroutine(hit.collider.GetComponent<Cookie> ().HideCookies (cookiesIndex));
					cookiesIndex++;
					m_CharacterController.transform.localScale += new Vector3 (0f, 0.4f, 0f);
				} 

				if(cookiesIndex > 3){
					//sound
					cookiesIndex = 0;
//					Vector3 targetSize = new Vector3 (10, 10, 10);
//					LeanTween.scale (m_CharacterController.gameObject, targetSize, 5f);
//					Debug.Log ("变大");
				}

			}
		}
	}
}
