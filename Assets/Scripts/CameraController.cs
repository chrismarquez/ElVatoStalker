using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public static float playerHealth;

	public Transform target;
	public float lookSmooth = 0.09f;
	public Vector3 offsetFromTarget = new Vector3(0,6,-8);
	public float xTilt = 10;

	Vector3 destination = Vector3.zero;
	CharacterControllerPlayer charController;
	float rotateVel = 0;

	void Start(){
		SetCameraTarget (target);
        playerHealth = 100;
	}

	public void SetCameraTarget(Transform t){
		target = t;

		if (target != null) {
			if (target.GetComponent<CharacterControllerPlayer> ()) {
				charController = target.GetComponent<CharacterControllerPlayer> ();
			} else {
				Debug.LogError ("camera's need charcontroller");
			}
		} else {
			Debug.LogError ("Camera needs target");
		}

	}

	void LateUpdate(){
		MoveToTarget ();
		LookAtTarget ();
	}

	void MoveToTarget(){
		destination = charController.TargetRotation * offsetFromTarget;
		destination += target.position;
		transform.position = destination;
	}

	void LookAtTarget(){
		float eulerYAngle = Mathf.SmoothDampAngle (transform.eulerAngles.y, target.eulerAngles.y, ref rotateVel, lookSmooth);
		transform.rotation = Quaternion.Euler (transform.eulerAngles.x, eulerYAngle, 0);
	}

    void OnGUI() {
        GUI.Label(new Rect(0, 0, 300, 300), "Health : " + playerHealth);
    }

}
