using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour 
{
    //Create a reference to the KeyPoofPrefab and Door
	private GameObject key;
	public GameObject door;
	public GameObject keyPoof;
	public static bool keyCollected;

	void Start() {
		key = GameObject.Find ("Key");
	}

	void Update()
	{
		//Bonus: Key Animation

	}

	public void OnKeyClicked()
	{
        // Instatiate the KeyPoof Prefab where this key is located
        // Make sure the poof animates vertically
        // Call the Unlock() method on the Door
        // Destroy the key. Check the Unity documentation on how to use Destroy
		GameObject newKeyPoof = (GameObject)Object.Instantiate (keyPoof, key.transform.position, Quaternion.identity);
		this.gameObject.GetComponent<AudioSource> ().Play ();
		keyCollected = true;
		door.GetComponent<Door>().Unlock();
		Destroy (key);
    }

}
