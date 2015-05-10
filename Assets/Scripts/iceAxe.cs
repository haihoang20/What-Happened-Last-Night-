using UnityEngine;
using System.Collections;

public class iceAxe : MonoBehaviour {

	public ParticleSystem explosion;
	public AudioSource pickupSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		Instantiate (explosion, transform.position, Quaternion.identity);
		pickupSound.Play ();
		explosion.Play ();
		PlayerMovementYV.hasItem = true;
		Destroy (gameObject);
	}
}
