using UnityEngine;
using System.Collections;

public class spin : MonoBehaviour {

	public float speed = 1;
	public bool isSpinning = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isSpinning == true) {
			transform.Rotate (0f, 360f * speed * Time.deltaTime, 0f);
		} else {
		}
	}
}
