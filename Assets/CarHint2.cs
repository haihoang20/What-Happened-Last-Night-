using UnityEngine;
using System.Collections;

[System.Serializable]

	
	public class CarHint2 : MonoBehaviour {
		
		public GUIText carHintText;
		//public float hintTime;
		public static bool hasFuel = false;
		public static bool hasPump = false;
		public AudioSource getAway;
		//private bool showCarHint = false;

	public GameObject blackScreen;
		
		//private bool usedKey = false;
		
		void Update()
		{
			
		}

	void showFirsthint()
	{
		if (PlayerMovementYV.hasKey) 
		{
			carHintText.text = "Let's try the key.. it worked!";
		}
	}

	void showSecondhint() {
		if (PlayerMovementYV.hasKey) {
			carHintText.text = "The car isn't starting...";
		}
	}
	
	void showThirdhint() {
		if (PlayerMovementYV.hasKey) {
			carHintText.text = "";
		}
	}
	
		IEnumerator OnTriggerEnter(Collider col)
		{
			if (col.tag == "Player")
			{

				if (PlayerMovementYV.hasKey && hasFuel && hasPump) 
				{
					//float fadeTime = GameObject.Find("OBJECT NAME HERE").GetComponent<Fading>().BeginFade(1);
					//driveAway.Play ();
				//Application.LoadLevel (Application.loadedLevel);
			

				getAway.Play();
				yield return new WaitForSeconds(4);
				Application.LoadLevel(4);

				} else {
				showFirsthint ();
				yield return new WaitForSeconds(2);
				showSecondhint();
				yield return new WaitForSeconds(2);
				showThirdhint();
			}

			
		}
		}
	}



