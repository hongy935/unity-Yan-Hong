using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class reset : MonoBehaviour {
	


	// Use this for initialization
	void Start () {
		Streetmaker.globalBuildingCount = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.R)) {
			Debug.Log ("Reset");
			SceneManager.LoadScene ("city_Yan");
		} else {
			Debug.Log ("Nothing");
		}

	
	}
}
