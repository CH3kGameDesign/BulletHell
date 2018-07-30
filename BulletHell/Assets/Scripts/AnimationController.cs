using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

	private Animator anim;

	public GameObject direction;
	public GameObject target;

	private float verticalDistance;
	private float horizontalDistance;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		


		if (direction.GetComponent<Transform> ().localRotation.eulerAngles.y > -40 && direction.GetComponent<Transform> ().localRotation.eulerAngles.y < 40) {
			anim.SetInteger ("Direction", 0);
			Debug.Log ("0");
		}
		if (direction.GetComponent<Transform> ().localRotation.eulerAngles.y > 50 && direction.GetComponent<Transform> ().localRotation.eulerAngles.y < 130) {
			anim.SetInteger ("Direction", 1);
			Debug.Log ("1");
		}
		if (direction.GetComponent<Transform> ().localRotation.eulerAngles.y < -50 && direction.GetComponent<Transform> ().localRotation.eulerAngles.y > -130) {
			anim.SetInteger ("Direction", 2);
			Debug.Log ("2");
		}
		if (direction.GetComponent<Transform> ().localRotation.eulerAngles.y < -140 || direction.GetComponent<Transform> ().localRotation.eulerAngles.y > 140) {
			anim.SetInteger ("Direction", 3);
			Debug.Log ("3");
		}


	}
}
