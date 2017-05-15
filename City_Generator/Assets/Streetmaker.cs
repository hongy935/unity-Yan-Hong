using UnityEngine;
using System.Collections;


public class Streetmaker : MonoBehaviour {

	public static int globalBuildingCount = 0;

	int stepCount = 0;

	public Transform streetMakerPrefab;

	public Transform buildingPrefab;

	public float buildSpace = 4f;

	// Update is called once per frame
	void Update () {
		transform.position += transform.forward * buildSpace;
		float randomNumber = (float)Random.Range (0f, 100f);
		if (randomNumber < 90f) {
			Instantiate (buildingPrefab, transform.position, transform.rotation);
			globalBuildingCount++;
			if (globalBuildingCount > 1000) {
				Destroy (gameObject);
			}

		} else {
			float anotherRandom = Random.Range (0f, 100f);

			if (anotherRandom < 50f) {
				Instantiate (streetMakerPrefab, transform.position, Quaternion.Euler (0f, transform.rotation.eulerAngles.y + 90f, 0f));
			} else {
				Instantiate (streetMakerPrefab, transform.position, Quaternion.Euler (0f, transform.rotation.eulerAngles.y - 90f, 0f));
			}
		}


		stepCount++;
		if (stepCount >= 15)
		{
			Destroy(gameObject);
		}
			

	}



}