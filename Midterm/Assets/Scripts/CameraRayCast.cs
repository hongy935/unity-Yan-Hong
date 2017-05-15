using UnityEngine;
using System.Collections;

public class CameraRayCast : MonoBehaviour {
	[SerializeField]
	bool LeftToggle,RightToggle,TopToggle = false;
	float Horizontal,Vertical;

	[SerializeField]
	float speed = 3f;

	[SerializeField]
	//AudioClip[] myAudioClips = new AudioClip[2];

	//AudioSource myAudioSource;
	//RaycastHit rayinfo = new RaycastHit();
	// Use this for initialization
	void Start () {
	//	myAudioSource = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float d = Input.GetAxis("Mouse ScrollWheel");
		if (LeftToggle && RightToggle && TopToggle) {// wheel zoom in 
			if (d > 0f)
			{
				Camera.main.transform.position = new Vector3 (Camera.main.transform.position.x,Camera.main.transform.position.y,Camera.main.transform.position.z+4);	 
				// scroll up
			}
			else if (d < 0f)
			{
				Camera.main.transform.position = new Vector3 (Camera.main.transform.position.x,Camera.main.transform.position.y,Camera.main.transform.position.z-4);
				// scroll down
			}
		}
		if (Camera.main.transform.position.z > 280) {//camera rotation
			//if(Horizontal<= 6f && Horizontal>= -6f){
				Horizontal += Input.GetAxis ("Mouse X");
			//}
			Vertical += Input.GetAxis ("Mouse Y");
			//Debug.Log (Horizontal);

			//if (Mathf.Cos (Camera.main.transform.rotation.eulerAngles.y * Mathf.Deg2Rad) > 0) {
				Camera.main.transform.rotation = Quaternion.Euler (-Vertical * speed, Horizontal * speed, 0);
			//}
//			else {
//				if (Camera.main.transform.rotation.eulerAngles.y >= 89 ) {
//					Camera.main.transform.rotation =  Quaternion.Euler(Camera.main.transform.rotation.eulerAngles.x,89f,Camera.main.transform.rotation.eulerAngles.z);
//				}
//
//				if (Camera.main.transform.rotation.eulerAngles.y <= -89) {
//					Camera.main.transform.rotation= Quaternion.Euler(Camera.main.transform.rotation.eulerAngles.x,-89f,Camera.main.transform.rotation.eulerAngles.z);
//				}
//			}
		}
		if (Input.GetMouseButtonDown (0)) {
			Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)){
				if (hit.collider.tag == "Left") {//left window interaction
					Animator myanimator = hit.collider.transform.GetChild (0).GetComponent<Animator> ();
					LeftToggle = !LeftToggle;
					myanimator.SetBool ("OpenClose", LeftToggle);
					//PlaySound (LeftToggle);
					// play sound
				}

				if (hit.collider.tag == "Right") {//right window interaction
					Animator myanimator = hit.collider.transform.GetChild (0).GetComponent<Animator> ();
					RightToggle = !RightToggle;
					myanimator.SetBool ("OpenClose", RightToggle);
					//PlaySound (RightToggle);

				}

				if (hit.collider.tag == "Top") {// top window interaction
					Animator myanimator = hit.collider.transform.GetChild (0).GetComponent<Animator> ();
					TopToggle = !TopToggle;
					myanimator.SetBool ("OpenClose", TopToggle);
					//PlaySound (TopToggle);
				}

			}
		
		}


	}
	/*
	void PlaySound(bool _toggle){

		if (_toggle) {
			myAudioSource.PlayOneShot (myAudioClips [0]);
		} else {
			myAudioSource.PlayOneShot (myAudioClips [1]);
		}
	}
	*/
}
