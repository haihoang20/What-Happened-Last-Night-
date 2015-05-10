using UnityEngine;
using System.Collections;

public class GameOverScreen : MonoBehaviour {

	public float smooth;

	public Light selectorLight;
	private Vector3 newPosition;

	public Material yesMaterial;
	public Material noMaterial;

	private bool currentYes;
	private bool currentNo;

	private Color originalDiffuseYes;
	private Color originalRimYes;

	private Color originalDiffuseNo;
	private Color originalRimNo;

	private Color selectedColor;
	private Color selectedRim;

	private Color savedColor;
	private Color savedRim;

	void Awake(){
		newPosition = new Vector3 (0.3f, -11.5f, 19.97f);

		selectedColor = new Color (0.0f, 0.4f, 1.0f);
		selectedRim = new Color (0.0f, 0.3f, 1.0f);
		savedColor = new Color (0.7f, 0.0f, 0.9f);
		savedRim = new Color (0.3f,0.9f,1.0f);

		yesMaterial.SetColor ("_DiffuseColor", savedColor);
		yesMaterial.SetColor ("_RimColor", savedRim);

		noMaterial.SetColor ("_DiffuseColor", savedColor);
		noMaterial.SetColor ("_RimColor", savedRim);

	}

	// Use this for initialization
	void Start () {
		originalDiffuseYes = savedColor;
		originalDiffuseNo = savedColor;

		originalRimNo = savedRim;
		originalRimYes = savedRim;

		currentYes = false;
		currentNo = false;
	}
	
	// Update is called once per frame
	void Update () {
		SelectOption ();
		ExitGameOver ();
	}

	void SelectOption(){
		Vector3 yesPosition = new Vector3 (-19.59f, -11.5f, 19.97f);
		Vector3 noPosition = new Vector3 (18.5f, -11.5f, 20.0f);

		if (Input.GetKeyDown (KeyCode.LeftArrow) == true) {
			newPosition = yesPosition;
			currentYes = true;
			currentNo = false;

			yesMaterial.SetColor("_DiffuseColor", selectedColor);
			yesMaterial.SetColor("_RimColor", selectedRim);

			noMaterial.SetColor("_DiffuseColor", originalDiffuseNo);
			noMaterial.SetColor("_RimColor", originalRimNo);
		}
		if (Input.GetKeyDown (KeyCode.RightArrow) == true) {
			newPosition = noPosition;
			currentNo = true;
			currentYes = false;

			noMaterial.SetColor("_DiffuseColor", selectedColor);
			noMaterial.SetColor("_RimColor", selectedRim);

			yesMaterial.SetColor("_DiffuseColor", originalDiffuseYes);
			yesMaterial.SetColor("_RimColor", originalRimYes);
		}

		selectorLight.transform.position = Vector3.Lerp (selectorLight.transform.position, newPosition, smooth * Time.deltaTime);
	}

	void ExitGameOver(){
		if ((currentYes == true) && (Input.GetKeyDown(KeyCode.Return) == true)) {
			Application.LoadLevel(1);
		}
		if ((currentNo == true) && (Input.GetKeyDown(KeyCode.Return) == true)) {
			Application.LoadLevel(4);		
		}
	}
}
