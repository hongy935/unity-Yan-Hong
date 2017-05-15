using UnityEngine;
using System.Collections;

public class RandomVector : MonoBehaviour {

	public float speed = 5f; // when you put "public" in front of a var, it shows up in Unity

	float lastTimeWhenIMoved = 0f;
	Vector3 myDestination; // remember where I want to move
	// Update is called once per frame


	// Update is called once per frame
	void Update () {

		transform.Rotate(0f, 360f * 5f * Time.deltaTime, 0f);

		if (Time.time > lastTimeWhenIMoved + 1f) {
			myDestination += new Vector3 (Random.Range (-0.5f, 0.5f),
				0f,
				Random.Range (-0.5f, 0.5f)
			);
			lastTimeWhenIMoved = Time.time;
		}





//		-------Not smooth movement---------
//		transform.position = Vector3.MoveTowards (transform.position,
//			myDestination,
//			Time.deltaTime
//		);

//		-------New movement to make it smoother---------
		transform.position = Vector3.Lerp( transform.position, 
			myDestination, 
			0.1f 
		);
	}
}
