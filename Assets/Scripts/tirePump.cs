using UnityEngine;
using System.Collections;

namespace CompleteProject
{
	
	public class tirePump : MonoBehaviour {
		  
		//public AudioClip refuel;
		public ParticleSystem explosion;
		
		//public AudioSource tirePump;
		
		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}
		
		
		void OnTriggerEnter(Collider col){
			Instantiate (explosion, transform.position, Quaternion.identity);
			//tirePump.enabled = true;
			//tirePump.Play ();
			explosion.Play ();
			CarHint2.hasPump = true;
			Destroy (gameObject);
		}
	}
}