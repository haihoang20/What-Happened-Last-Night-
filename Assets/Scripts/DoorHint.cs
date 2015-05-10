using UnityEngine;
using System.Collections;

public class DoorHint : MonoBehaviour {


	public GUIText doorHintText;
	public float hintTime;
	//public AudioClip doorSlideSound;
	public AudioSource doorScreech;
	private bool showDoorHint = false;
	public AudioSource doorRattle;

	void Update()
	{
		if (showDoorHint) 
		{
			doorHintText.text = "The door seems to be locked!";
		} else
			doorHintText.text = "";
	}

	IEnumerator OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player") {
				if (PlayerMovementYV.hasKey) {
				doorScreech.Play ();
				PlayerMovementYV.hasKey = false;
				yield return new WaitForSeconds (2);
				doorOpen ();
						} 
			else {

				showDoorHint = true;
				doorRattle.Play ();
				yield return new WaitForSeconds (hintTime);
				showDoorHint = false;
						}
				}
	}

	void doorOpen(){

		//Instantiate (fridge, transform.position, Quaternion.identity);
		//yield return new WaitForSeconds (5);

		Application.LoadLevel (2);
	}
	}
