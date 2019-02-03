using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour {

    
	public float pushForce = 1;

    public GameObject damageCounter;
    public int damageMin = 2;
	public int damageMax = 2;

	private float preDamage;
	public int damage;

	public Vector3 shotOrigin;

    public float destroyTime = 3;
	public GameObject destroyedArea;

	private List<GameObject> HitPeople = new List<GameObject> ();

    //Camera Shake
    public float shakeDuration;
    public float shakeAmount;
    private Camera cameraMain;

	void Start () {
		shotOrigin = transform.position;
		preDamage = Random.Range (damageMin, damageMax);
		damage = Mathf.RoundToInt (preDamage);

        cameraMain = Camera.main;
		Invoke ("DestroyTime", destroyTime);
    }

    // Update is called once per frame
	void FixedUpdate () {
		
	}

	public void OnTriggerStay(Collider other)
	{
		bool prevHit = false;
		for (int i = 0; i < HitPeople.Count; i++) {
			if (other.gameObject == HitPeople[i])
				prevHit = true;
		}
		if (prevHit == false) {
			
			if (other.tag == "Enemy") {
			
				HitPeople.Add (other.gameObject);
				if (other.GetComponentInChildren<GuardVisionCone> ().chasing == false) {
					other.GetComponent<Guard> ().playersLastKnownPosition = shotOrigin;
					other.GetComponentInChildren<GuardVisionCone> ().chasing = true;
					other.GetComponentInChildren<GuardVisionCone> ().chaseePosition = shotOrigin;
				}
				preDamage = Random.Range (damageMin, damageMax);
				damage = Mathf.RoundToInt (preDamage);

				Debug.Log ("BBOOOOMM ENEMY");

				GameObject thisDamageCounter = Instantiate (damageCounter, transform.position + new Vector3 (0, 2, 0), Quaternion.Euler (new Vector3 (80, 0, 0)));
				thisDamageCounter.GetComponent<TextMesh> ().text = damage.ToString ();
				other.GetComponent<Enemy> ().Health -= damage;
				other.GetComponent<Enemy> ().bulletPos = transform.position;
				//other.transform.position = other.transform.position + transform.forward;
				other.transform.position += (other.transform.position - transform.position);

				cameraMain.GetComponent<CameraController> ().shakeAmount = shakeAmount * 0.7f;
				cameraMain.GetComponent<CameraController> ().shakeDuration = shakeDuration;
			}

        
			if (other.tag == "Player") {
				HitPeople.Add (other.gameObject);
				if (other.GetComponent<PlayerHealth> ().invulnerable == false) {
					preDamage = Random.Range (damageMin, damageMax);
					damage = Mathf.RoundToInt (preDamage);

					Debug.Log ("BBOOOOMM PLAYER" + damage);

					GameObject thisDamageCounter = Instantiate (damageCounter, transform.position + new Vector3 (0, 2, 0), Quaternion.Euler (new Vector3 (80, 0, 0)));
					thisDamageCounter.GetComponent<TextMesh> ().text = damage.ToString ();
					thisDamageCounter.GetComponent<TextMesh> ().color = Color.red;
					other.GetComponent<PlayerHealth> ().health -= damage;
					//other.GetComponent<Rigidbody> ().MovePosition (other.transform.position + transform.forward);
					other.GetComponent<Rigidbody> ().MovePosition (other.transform.position + (other.transform.position - transform.position));
                
					cameraMain.GetComponent<CameraController> ().shakeAmount = shakeAmount * 0.7f;
					cameraMain.GetComponent<CameraController> ().shakeDuration = shakeDuration;
				}
			}
			if (other.tag != "Player" && other.tag != "Enemy") {
				HitPeople.Add (other.gameObject);
				if (other.GetComponent<Rigidbody> () != null) {

					Debug.Log ("BBOOOOMM OTHER");

					Rigidbody body = other.gameObject.GetComponent<Rigidbody> ();

					if (body != null && body.isKinematic == false) {
						//body.AddForceAtPosition (transform.forward * pushForce, transform.position, ForceMode.Impulse);
						body.AddExplosionForce(pushForce, transform.position, GetComponent<SphereCollider>().radius);
					}
				}
				cameraMain.GetComponent<CameraController> ().shakeAmount = shakeAmount * 0.7f;
				cameraMain.GetComponent<CameraController> ().shakeDuration = shakeDuration;			
			}
		}

	}

	private void DestroyTime ()
	{
		if (destroyedArea != null) {
			GameObject GO = Instantiate (destroyedArea, transform.position, transform.rotation);
			//GO.GetComponent<Rigidbody> ().velocity = transform.forward * bulletSpeed / 10;
		}
		Destroy (this.gameObject);
	}
}
