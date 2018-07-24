using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    /*
    WHAT SCRIPT DOES:
    -   Moves Player
    -   Jump
    -   Respawns Character
    */

	public float speed = 2;                         //Character Speed
	public float gravity = 10;
	public float pushForce = 0.1f;

	public Rigidbody rb;                            //Rigidbody Reference

	public Vector3 respawn;                         //Respawn Location                  Set at Start in CharacterSelect
	public Quaternion respawnRotation;              //Respawn Rotation                  Set at Start in CharacterSelect

	public bool notdead;

	public Vector3 moveDirection;

	// Use this for initialization
	void Start () {
        //Set Variables
		rb = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
        //Movement

        ///////////////////////////////////
        
            //Movement Relative To Camera
		CharacterController controller = GetComponent<CharacterController>();
			
		moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		moveDirection = transform.TransformDirection(moveDirection);
		moveDirection *= 200;
		moveDirection = Vector3.ClampMagnitude (moveDirection, speed);

		//rb.MovePosition(transform.position + Vector3.ClampMagnitude(moveDirection, speed));

		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}




    //Respawn
	void RespawnAction () {
		transform.position = respawn;
		transform.rotation = respawnRotation;
		notdead = true;

        GetComponent<Rigidbody> ().velocity = Vector3.zero;
        
		transform.eulerAngles = Vector3.zero;
		GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
	}

	void OnTriggerStay (Collider hit)
	{
		Rigidbody body = hit.gameObject.GetComponent<Rigidbody> ();

		if (body != null && body.isKinematic == false) {
			body.AddForceAtPosition (new Vector3 (moveDirection.x, 0, moveDirection.z) * pushForce, transform.position, ForceMode.Impulse);
		}
		Debug.Log ("IM PUSHING");
	}
}
