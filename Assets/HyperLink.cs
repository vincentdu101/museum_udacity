using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperLink : MonoBehaviour {

	public string link;

	// Use this for initialization
	void Start () {
		Application.OpenURL ("www.google.com");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void goToLink() {
		Debug.Log ("test");
		Application.OpenURL ("www.google.com");
	}
}
