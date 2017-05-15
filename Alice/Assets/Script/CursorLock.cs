using UnityEngine;
using System.Collections;

public class CursorLock : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//if the user clicks, then lock cursor

		if (Input.GetMouseButtonDown (0)) {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;

		}
	}
}
