using UnityEngine;
using System.Collections;

namespace CompleteProject
{
	
	public class gasFuelForCar : MonoBehaviour {
		  
		//public AudioClip refuel;
		public ParticleSystem explosion;
		
		public AudioSource carFuelPickUp;
		
		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}
		
		
		void OnTriggerEnter(Collider col){
			if (col.gameObject.tag == "Player") {
				Instantiate (explosion, transform.position, Quaternion.identity);
				carFuelPickUp.enabled = true;
				carFuelPickUp.Play ();
				CarHint2.hasFuel = true;
				explosion.Play ();
				Destroy (gameObject);
			}
		}
	}
}