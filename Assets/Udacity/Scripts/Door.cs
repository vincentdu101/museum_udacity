using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour 
{
    // Create a boolean value called "locked" that can be checked in Update() 
	bool locked = true;

	IEnumerator AnimateUnlock() {
		Vector3 originalPosition = transform.position;
		this.gameObject.GetComponent<AudioSource> ().Play ();
		for (int x = 0; x < 14; x++) {
			transform.position = new Vector3(originalPosition.x, transform.position.y + 1, originalPosition.z);
			yield return new WaitForSeconds (0.1f);
		}
		Destroy (this.gameObject);
	}

    void Update() {
        // If the door is unlocked and it is not fully raised
            // Animate the door raising up
		if (!locked && Key.keyCollected) {
			StartCoroutine (AnimateUnlock ());
		}
    }

	public void DoorClick() {
		if (!locked && Key.keyCollected) {
			StartCoroutine (AnimateUnlock ());
		} else {
			this.gameObject.GetComponent<AudioSource> ().Play ();
		}
	}

    public void Unlock()
    {
        // You'll need to set "locked" to true here
		locked = false;
    }
}
