using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour 
{
	void OnGUI()
	{

		if (GUI.Button (new Rect (Screen.width / 1.8f, Screen.height / 2.5f, Screen.width / 5, Screen.height/10), "Start Game")) 
		{
			Application.LoadLevel (1);
		}
		if (GUI.Button (new Rect (Screen.width / 1.8f, Screen.height / 1.5f, Screen.width / 5, Screen.height/10), "Credits")) 
		{
			Application.LoadLevel(4);
			
		}
	}
}