using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	private Animator aEnemy;
    CharacterController charC;
    GameObject player;
    public float speed = 1;

	// Use this for initialization
	void Start () {   
		this.aEnemy = this.GetComponent<Animator> ();
        this.charC = this.GetComponent<CharacterController>();
        this.player = GameObject.Find("Douglas");
        base.StartCoroutine("AI");
	}

    // Update is called once per frame
    void Update()
    { 

    }

    public IEnumerator AI()
    {
        while (true) {
            this.aEnemy.SetInteger("movement", 1);
            Vector3 pointToPlayer = this.player.transform.position - this.transform.position;
            this.transform.LookAt(this.player.transform);
            this.charC.SimpleMove(pointToPlayer * speed);
            yield return new WaitForFixedUpdate();
            //animation transitions
        }
    }

    public void startAI()
    {
        this.StartCoroutine("AI");
    }
    public void stopAI()
    {
        this.aEnemy.SetInteger("movement", 0);
        this.StopAllCoroutines();
    }


}
