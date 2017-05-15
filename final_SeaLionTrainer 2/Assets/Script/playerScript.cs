using UnityEngine;
using System.Collections;

public class playerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.A)) {
			randomGenerate.left = true;
		} else {
			randomGenerate.left = false;		
		}

		if (Input.GetKey (KeyCode.D)) {
			randomGenerate.right = true;
			//Debug.Log ("D");
		} else {
			randomGenerate.right = false;		
		}

		if (Input.GetKey (KeyCode.H)) {
			randomGenerate.jump = true;
		} else {
			randomGenerate.jump = false;		
		}

		if (Input.GetKey (KeyCode.J)) {
			randomGenerate.shake = true;
		} else {
			randomGenerate.shake = false;		
		}

		if (Input.GetKey (KeyCode.K)) {
			randomGenerate.clap = true;
		} else {
			randomGenerate.clap = false;		
		}
	}
}
