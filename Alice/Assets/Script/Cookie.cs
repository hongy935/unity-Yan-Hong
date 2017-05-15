using UnityEngine;
using System.Collections;

public class Cookie : MonoBehaviour {
	[SerializeField]
	GameObject[] cookies;
	// Use this for initialization

	public bool isEmpty;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public IEnumerator HideCookies(float _Index){
		if (_Index >= 3) {
			isEmpty = true;
			cookies[3].GetComponent<MeshRenderer> ().enabled = false;

			yield return new WaitForSeconds (1);
			isEmpty = false;
			for (int i = 0; i < cookies.Length; i++) {
				cookies[i].GetComponent<MeshRenderer> ().enabled = true;
			}

		} else{
//			SoundManager.instance.PlayMusic(1);
			cookies [(int)_Index].GetComponent<MeshRenderer> ().enabled = false;
			yield return new WaitForSeconds (0);
		
		}
		Debug.Log (_Index);
	}
}
