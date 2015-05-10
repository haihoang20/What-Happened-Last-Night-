using UnityEngine;

namespace CompleteProject
{
	[RequireComponent(typeof(Light))]
	public class Lantern : MonoBehaviour
	{
		public PlayerHealth playerHealth;       // Reference to the player's health.
		
		private float scaling = 0.5f;

		public static float newRange;

		
		void Update ()
		{
			
			newRange = playerHealth.currentHealth * scaling; 

			light.range = newRange;
			
		}
	}
}
