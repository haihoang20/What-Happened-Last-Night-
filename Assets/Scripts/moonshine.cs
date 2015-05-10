using UnityEngine;
using System.Collections;

public class moonshine : MonoBehaviour {

	public ParticleSystem explosion;
	public ParticleSystem keyShine;
	public float force;
	public GameObject keyItem;
	public AudioSource pickupSound;





	void OnTriggerEnter(Collider col){
		if (PlayerMovementYV.hasItem == true) {
			Instantiate (explosion, transform.position, Quaternion.identity);
			Instantiate (keyItem, transform.position, Quaternion.identity);
			pickupSound.Play ();
			explosion.Play ();
			keyShine.Play ();
			Vector3 moonshineLocation = this.transform.position;
			Vector3 playerLocation = col.transform.position;
			Vector3 newVector = moonshineLocation - playerLocation;
			newVector.Normalize();
			col.rigidbody.AddForce (newVector* (-1 * force), ForceMode.Impulse);
			Destroy (gameObject);
		}
	}
}
