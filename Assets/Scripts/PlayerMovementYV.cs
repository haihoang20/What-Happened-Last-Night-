using UnityEngine;
[System.Serializable]

public class PlayerMovementYV : MonoBehaviour
{
	public float speed = 6f; //f means floating point variable
	public static bool hasItem = false;
	public static bool hasKey = false;

	Vector3 movement;
	Animator anim;
	Rigidbody playerRigidbody;

	void Awake()
	{
		anim = GetComponent<Animator> ();
		playerRigidbody = GetComponent<Rigidbody> ();
	}

	void Update() {
		Turning ();
		}

	void FixedUpdate()
	{
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

		Move (h, v);
		Animating (h, v);
	}

	void Move (float h, float v)
	{
		movement.Set (h, 0f, v);

		movement = movement.normalized * speed * Time.deltaTime; //normalizing the movement when pressing W and D

		playerRigidbody.MovePosition (transform.position + movement);
	}



	void Turning () {

		if (Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.LeftArrow)) {
					transform.rotation = Quaternion.Euler (0, -90, 0);
				}
		
		if (Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown (KeyCode.RightArrow)) {
						transform.rotation = Quaternion.Euler (0, 90, 0);
				}

		if (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow)) {
			transform.rotation = Quaternion.Euler (0, 0, 0);
		}
		
		if (Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.DownArrow)) {
			transform.rotation = Quaternion.Euler (0, 180, 0);
		}
		
	}
	
	
	void Animating(float h, float v)
	{
		bool walking = h != 0f || v != 0f;
		anim.SetBool ("IsWalking", walking);
	}



}
