using UnityEngine;
using System.Collections;

public class CharacterControllerPlayer : MonoBehaviour {

	public float inputDelay = 0.1f;
	public float forwardVel = 12;
	public float rotateVel = 100;

    private EnemyBehaviour enemyScript;

	Quaternion targetRotation;
	Rigidbody rBody;
	float forwardInput, turnInput;

	Animator anim;

	public Quaternion TargetRotation{
		get{ return targetRotation;}
	}

	// Use this for initialization
	void Start () {
        this.enemyScript = GameObject.Find("enemy").GetComponent<EnemyBehaviour>();
		targetRotation = transform.rotation;
		rBody = GetComponent<Rigidbody> ();
		forwardInput = turnInput = 0;

		anim = GetComponent<Animator> ();
	}

	void GetInput(){
		forwardInput = Input.GetAxis ("Vertical");
		turnInput = Input.GetAxis ("Horizontal");
	}

	// Update is called once per frame
	void Update () {
		GetInput ();
		Turn ();

		if (forwardInput != 0) {
			anim.SetBool ("isWalking", true);
		} else {
			anim.SetBool ("isWalking", false);
		}

		if ((forwardInput != 0) &&(Input.GetKeyDown (KeyCode.LeftControl))) {
			anim.SetBool ("isRunning", true);
		} else {
			anim.SetBool ("isRunning", false);
		}


	}

	void FixedUpdate () {
		Run ();
	}

	void Run(){
		if (Mathf.Abs (forwardInput) > inputDelay) {
			rBody.velocity = transform.forward * forwardInput * forwardVel;
		} else {
			rBody.velocity = Vector3.zero;
		}
	}

	void Turn(){
		/*
		if(Mathf.Abs (forwardInput) > inputDelay){
			targetRotation *= Quaternion.AngleAxis (rotateVel * turnInput * Time.deltaTime, Vector3.up);
		}
		*/
		targetRotation *= Quaternion.AngleAxis (rotateVel * turnInput * Time.deltaTime, Vector3.up);
		transform.rotation = targetRotation;
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "enemy")
        {
            CameraController.playerHealth -= 20;
            base.StartCoroutine(enemyHit(true));
        }
    }

    IEnumerator enemyHit(bool arg) {
        bool i = arg;
        while (true) {
            if (i) {
                this.enemyScript.stopAI();
                i = !i;
                yield return new WaitForSeconds(3);
            } else {
                this.enemyScript.startAI();
                yield return 0;
                break;
            }
        }
    }
}
