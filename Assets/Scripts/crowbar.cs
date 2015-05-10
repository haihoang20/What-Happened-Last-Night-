using UnityEngine;
using System.Collections;

public class crowbar : MonoBehaviour {

	public ParticleSystem explosion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		Instantiate (explosion, transform.position, Quaternion.identity);
		explosion.Play ();
		PlayerMovementYV.hasItem = true;
		Destroy (gameObject);
	}
}
