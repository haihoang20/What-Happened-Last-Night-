using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

	public AudioSource keySound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter(Collider col){
		if (col.tag == "Player") {
			Instantiate (keySound, transform.position, Quaternion.identity);
			keySound.Play();
			//sparks.Play ();
			PlayerMovementYV.hasKey = true;

			Destroy (gameObject);	
		}

	}
}
