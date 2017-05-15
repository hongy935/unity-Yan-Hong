using UnityEngine;
using System.Collections;

public class DestroyIce : MonoBehaviour {

	public GameObject scoreDisplay;
	public static int score=0;

	public GameObject great;



	// Use this for initialization
	void Start () {
		//score = 0;
	}

	// Update is called once per frame
	void Update () {
		


	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Player") {
			//Debug.Log("prefab destroyed");
			Destroy (this.gameObject);
			score++;
		}
		if (col.gameObject.tag == "water") {
			Destroy (this.gameObject);
			great.GetComponent<MeshRenderer> ().enabled = false;
		}
	}
}
