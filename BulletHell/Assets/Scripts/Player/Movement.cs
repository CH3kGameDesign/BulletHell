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
	public float gravity = 10;						//How Fast You Fall (Set Really High, Its Sorta Just For Going Down Ramps At This Point)
	public float pushForce = 0.1f;					//How Much You Can Push Stuff

	public bool notdead;							//Whether Dead Or Not

	public Vector3 moveDirection;					//Where Moving To

	void Start () {
        
	}

	// Update is called once per frame
	void FixedUpdate () {
        //Movement
		CharacterController controller = GetComponent<CharacterController>();
			
		moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		moveDirection = transform.TransformDirection(moveDirection);
		moveDirection *= 200;
		moveDirection = Vector3.ClampMagnitude (moveDirection, speed);

		//rb.MovePosition(transform.position + Vector3.ClampMagnitude(moveDirection, speed));

		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
		

	// PUUUUUUUUSH
	void OnTriggerStay (Collider hit)
	{
		Rigidbody body = hit.gameObject.GetComponent<Rigidbody> ();

		if (body != null && body.isKinematic == false) {
			body.AddForceAtPosition (new Vector3 (moveDirection.x, 0, moveDirection.z) * pushForce, transform.position, ForceMode.Impulse);
		}
	}

    public void KnockBack (float knockBack, Vector3 forward)
    {
            GetComponent<CharacterController>().Move(- forward * knockBack);
    }
}
