using UnityEngine;
using System.Collections;

public class door : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if (PlayerMovementYV.hasKey == true) {
			doorOpen();
		} else {
		//TODO
			//something to do with popping up a message. Perhaps particle system?
		}
	}

	void doorOpen(){
		//TODO
	}
}
