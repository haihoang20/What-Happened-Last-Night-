

	using UnityEngine;
	using System.Collections;
	[System.Serializable]
	
	
	public class Car : MonoBehaviour {
		
		public GUIText carHintText;
		public float hintTime;
		public static bool hasFuel = false;
		public static bool hasPump = false;
		//public AudioSource driveAway;
		private bool showCarHint = false;

		private bool usedKey = false;
		
		void Update()
		{
			if (showCarHint && !usedKey && PlayerMovementYV.hasKey) 
			{
				carHintText.text = "Let's try the key.. it worked!";
				usedKey = true;
			} else
				carHintText.text = "";

			if (showCarHint && usedKey && PlayerMovementYV.hasKey) 
			{
				carHintText.text = "The car isn't starting...";
			} else
				carHintText.text = "";
		}
		
		IEnumerator OnTriggerEnter(Collider col)
		{
			if (col.tag == "Player")
			{
				if (PlayerMovementYV.hasKey && hasFuel && hasPump) 
				{
					float fadeTime = GameObject.Find("Hearse").GetComponent<Fading>().BeginFade(1);
					//driveAway.Play ();
					
				} else {
					showCarHint = true;
					yield return new WaitForSeconds (hintTime);
					showCarHint = false;
				}
			}
		}
	}

