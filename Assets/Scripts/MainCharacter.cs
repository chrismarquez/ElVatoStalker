using UnityEngine;
using System.Collections;

public class MainCharacter : MonoBehaviour {

	Animator aMain;

	// Use this for initialization
	void Start () {
	
		aMain = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		//float h = Input.GetAxis ("Horizontal");
	
		int v = (int)Input.GetAxisRaw ("Vertical");
		bool run = Input.GetKey(KeyCode.Space);



		if (run && v > 0){
			v++ ;
		}

		Debug.Log (v + "");

		//Controller configurations
		//controller.SimpleMove (new Vector3(h * 5, 0, 0));

		//animation transitions
		aMain.SetInteger ("walking", (int)v);



		//
	
	}
}
