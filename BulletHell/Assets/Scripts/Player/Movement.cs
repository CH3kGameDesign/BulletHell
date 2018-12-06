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
    public float rollSpeed = 0.3f;
    public float rollLength = 1f;
    private float rollMultiplier = 1f;
    public float gravity = 10;						//How Fast You Fall (Set Really High, Its Sorta Just For Going Down Ramps At This Point)
	public float pushForce = 0.1f;					//How Much You Can Push Stuff

	public bool notdead;							//Whether Dead Or Not

    
    public bool rolling;

	public Vector3 moveDirection;					//Where Moving To
    public Vector3 rollDirection;                   

    void Start () {
        rolling = false;
	}

	// Update is called once per frame
	void FixedUpdate () {
        //Movement
        Rigidbody rb = GetComponent<Rigidbody>();
		CharacterController controller = GetComponent<CharacterController>();
        
		moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= 200;
        if (rolling == false)
        {
            moveDirection = Vector3.ClampMagnitude(moveDirection, speed);

            rb.MovePosition(transform.position + moveDirection);                //Speed Needs To Be 0.2

            //moveDirection.y -= gravity * Time.deltaTime;
            //controller.Move(moveDirection * Time.deltaTime);                  //Speed Needs To Be 9
            if (Input.GetMouseButton(1) && (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0))
            {
                GetComponentInChildren<SpriteChange>().RollColour();
                rollDirection = moveDirection;
                rollDirection *= 100;
                rolling = true;
                GetComponent<PlayerHealth>().invulnerable = true;
                rollMultiplier = 1f;
                Invoke("StopRolling", rollLength);
            }
        }
        else
        {
            rollDirection = Vector3.ClampMagnitude(rollDirection, rollSpeed * rollMultiplier);
            rollMultiplier -= 0.02f;
            rb.MovePosition(transform.position + rollDirection);
        }
        
	}
		
    void StopRolling ()
    {
        rolling = false;
        GetComponent<PlayerHealth>().invulnerable = false;
        GetComponentInChildren<SpriteChange>().UpdateColour();
    }

	// PUUUUUUUUSH
    /*
	void OnTriggerStay (Collider hit)
	{
		Rigidbody body = hit.gameObject.GetComponent<Rigidbody> ();

		if (body != null && body.isKinematic == false) {
			body.AddForceAtPosition (new Vector3 (moveDirection.x, 0, moveDirection.z) * pushForce, transform.position, ForceMode.Impulse);
		}
	}
    */

    public void KnockBack (float knockBack, Vector3 forward)
    {
            GetComponent<Rigidbody>().MovePosition(transform.position - (forward * knockBack));
    }
}
