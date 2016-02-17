using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	Animator aEnemy;

	// Use this for initialization
	void Start () {

		aEnemy = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		int v = 1;

		//Controller configurations


		//controller.SimpleMove (new Vector3(h * 5, 0, 0));

		//animation transitions

		aEnemy.SetInteger ("movement", (int)v);



		//
	
	}
}
