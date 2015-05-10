using UnityEngine;
using System.Collections;

namespace CompleteProject {

public class EnemyAI : MonoBehaviour {

	
	public Transform target;
	public float moveSpeed;
	public float rotationSpeed;
	public float maxdistance;
	private Transform myTransform;
	public PlayerHealth playerHealth;
	public GameObject player;
		public AudioSource zombie;
  
	
	void Awake()
	{
		myTransform = transform;
	}

	
	
	void Update ()
	{
		
		
		if (Vector3.Distance(target.position, myTransform.position) > maxdistance)
		{
			// Get a direction vector from us to the target
			Vector3 dir = target.position - myTransform.position;
			
			// Normalize it so that it's a unit direction vector
			dir.Normalize();

			transform.LookAt (target);

			// Move ourselves in that direction
			myTransform.position += dir * moveSpeed * Time.deltaTime;
		}
	}

	void OnTriggerEnter(Collider col){

		if (col.gameObject == player) {
			playerHealth.setHealth (0.0f);
				zombie.Play();
				}

	}
}
}
