using UnityEngine;
using System.Collections;

namespace CompleteProject
{
		
	public class gasTank : MonoBehaviour {

		public PlayerHealth playerHealth;  
		//public AudioClip refuel;
		public ParticleSystem explosion;

		public AudioSource gasFill;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter(Collider col){
						if (col.gameObject.tag == "Player") {
								Instantiate (explosion, transform.position, Quaternion.identity);
								gasFill.enabled = true;
								gasFill.Play ();
								explosion.Play ();
								playerHealth.setHealth (140.0f);
								Destroy (gameObject);
						}
				}
	}
}