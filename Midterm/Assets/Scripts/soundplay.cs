using UnityEngine;
using System.Collections;

public class soundplay : MonoBehaviour {
	//[SerializeField]
	AudioSource myaudiosource;
	[SerializeField]
	AudioClip[] myaudClip = new AudioClip[2];
	// Use this for initialization
	void Start () {
		myaudiosource = Camera.main.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayOpenSound(){
		
		myaudiosource.PlayOneShot (myaudClip [1]);
	}

	public void PlayClosSound(){
		myaudiosource.PlayOneShot (myaudClip [0]);
	}
}
