using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
	public static SoundManager instance;
	[SerializeField]
	AudioClip[] clips;

	[SerializeField]
	AudioSource myAudioSource;


	// Use this for initialization
	void Start () {
		if (instance == null) {
			instance = this;
		}
	}
	/// <summary>
	/// Plaies the music.
	/// </summary>
	/// <param name="_num">0 is drinking, 1 is eating cookie</param>
	public void PlayMusic(int _num){
//		myAudioSource.Stop ();
		myAudioSource.PlayOneShot (clips [_num]);
	}


	public void StopMusic(){
		//		myAudioSource.Stop ();
		myAudioSource.Stop();
	}
	// Update is called once per frame
	void Update () {
	
	}
}
