using UnityEngine;
using System.Collections;

public class KeyHint : MonoBehaviour {

	public GUIText keyHintText;
	public float hintTime;
	//public AudioClip doorSlideSound;
	
	private bool showKeyHint = false;
	private bool usedKey = false;
	
	void Update()
	{
		if (showKeyHint && PlayerMovementYV.hasKey) 
		{
			keyHintText.text = "Let me try the key... it worked!";
		} else
			keyHintText.text = "";

		if (PlayerMovementYV.hasKey && usedKey && showKeyHint) {
						keyHintText.text = "The car isn't starting...";
				}
				else
						keyHintText.text = "";


	}
	
	IEnumerator OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player") {
			if (PlayerMovementYV.hasKey) {
				usedKey = true;
			}
				showKeyHint = true;
				yield return new WaitForSeconds (hintTime);
				showKeyHint = false;
			}
	}
}

