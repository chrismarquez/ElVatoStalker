using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {


	Animator aMain;

	// Use this for initialization
	void Start () {

		aMain = GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
		void Update () {
	


		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		//controller settings
		//controller.SimpleMove (new Vector3(h * 5, 0, v*5));


		aMain.SetInteger ("walk", (int)h);

	}
}
