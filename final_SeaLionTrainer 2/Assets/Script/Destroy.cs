using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {


	public static int score=0;

	public GameObject loseText;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		


	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Player") {
			//Debug.Log("prefab destroyed");
			Destroy (this.gameObject);


			randomGenerate.clapToRestart = true;


		}
		if (col.gameObject.tag == "water") {
			
			Destroy (this.gameObject);
		}
	}





}
