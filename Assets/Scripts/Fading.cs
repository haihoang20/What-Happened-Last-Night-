using UnityEngine;
using System.Collections;

public class Fading : MonoBehaviour {


	//public Texture2D fadedOutTexture; //Texture to overlay Screen





	public float fadeSpeed = 0.8f; // Fade speed

	private int drawDepth = -1000; // texture's order in the draw hierarchy: low number means render on top
	private float alpha = 1.0f; // the texture's alpha value between 0 and 1
	private int fadeDir = -1; // the direction to fade in = -1 or out =1

	void OnGUI () {

		Texture2D blackTexture = new Texture2D (1, 1);
		blackTexture.SetPixel(0,0,Color.black);
		blackTexture.Apply();

		//fade out/in the alpha value using a direction, a speed and Time.deltatime to convert the operation to seconds
		alpha += fadeDir + fadeSpeed * Time.deltaTime;

		//force (clamp) the number between 0 and 1 because GUI.color uses alpha value between 0 and 1
		alpha = Mathf.Clamp01 (alpha);

		//set color of our GUI (in this case our texture). All colours  remain the same & the alpha is set to the alpha variable
		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b); // set the alpha value
		GUI.depth = drawDepth; // make black texture render on top (draw last)
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), blackTexture); //draw texture to fit screen area
	}

	//sets fadeDir to the direction parameter making the scene fade in if -1 and out if 1
		public float BeginFade (int direction) {
				fadeDir = direction;
		return (fadeSpeed); // return the fadeSpeed variable so it's easy to time the Application.LoadLevel();
		}

	//OnLevelWasLoaded is called when a level is loaded. It takes loaded level index (int) so you can limit the fade to certain scenes
		void OnLevelWasLoaded() {		
			BeginFade(-1); //alpha=-1, use this if the alpha is not set to 1 by default
}
}
