using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {

	public float speed = 10.0f;
	public float rotationSpeed = 100.0f;
	public float rotation;

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		float translation = Input.GetAxis ("Vertical") * speed;
		rotation = Input.GetAxis ("Horizontal") * rotationSpeed;
		translation *= Time.deltaTime;
		rotation *= Time.deltaTime;
		transform.Translate (0,0,translation);
		transform.Rotate (0,rotation,0);

		if (translation != 0) {
			anim.SetBool ("isWalking", true);
		} else {
			anim.SetBool ("isWalking", false);
		}

	}
}
