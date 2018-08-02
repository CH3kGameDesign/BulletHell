using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public bool playerBullet;

	public float bulletSpeed = 20;
	public float pushForce = 1;

    public Vector3 shotOrigin;

    public GameObject damageCounter;
    public int damageMin = 2;
	public int damageMax = 2;

	private float preDamage;
	public int damage;

    //Camera Shake
    public float shakeDuration;
    public float shakeAmount;
    private Camera cameraMain;

	void Start () {
        shotOrigin = transform.position;
		preDamage = Random.Range (damageMin, damageMax);
		damage = Mathf.RoundToInt (preDamage);

        cameraMain = Camera.main;
        cameraMain.GetComponent<CameraController>().shakeAmount = shakeAmount;
        cameraMain.GetComponent<CameraController>().shakeDuration = shakeDuration;
    }

    // Update is called once per frame
    void FixedUpdate () {
		transform.position += transform.forward * Time.deltaTime * bulletSpeed;
		Destroy (this.gameObject, 3);
	}

	public void OnTriggerStay(Collider other)
	{
        if (other.tag == "Enemy" && playerBullet == true)
        {
            if (other.GetComponentInChildren<GuardVisionCone>().chasing == false)
            {
                other.GetComponent<Guard>().playersLastKnownPosition = shotOrigin;
                other.GetComponentInChildren<GuardVisionCone>().chasing = true;
                other.GetComponentInChildren<GuardVisionCone>().chaseePosition = shotOrigin;
            }
            GameObject thisDamageCounter = Instantiate(damageCounter, transform.position + new Vector3 (0, 2, 0), Quaternion.Euler(new Vector3(80, 0, 0)));
            thisDamageCounter.GetComponent<TextMesh>().text = damage.ToString();
            other.GetComponent<Enemy>().Health -= damage;
            other.GetComponent<Enemy>().bulletPos = transform.position;
            other.transform.position = other.transform.position + transform.forward;

            cameraMain.GetComponent<CameraController>().shakeAmount = shakeAmount * 0.7f;
            cameraMain.GetComponent<CameraController>().shakeDuration = shakeDuration;
            Destroy(this.gameObject);

        }
        if (other.tag == "Player" && playerBullet == false)
        {
            if (other.GetComponent<PlayerHealth>().invulnerable == false)
            {
                GameObject thisDamageCounter = Instantiate(damageCounter, transform.position + new Vector3(0, 2, 0), Quaternion.Euler(new Vector3(80, 0, 0)));
                thisDamageCounter.GetComponent<TextMesh>().text = damage.ToString();
                thisDamageCounter.GetComponent<TextMesh>().color = Color.red;
                other.GetComponent<PlayerHealth>().health -= damage;
                other.GetComponent<Rigidbody>().MovePosition(other.transform.position + transform.forward);
                
                cameraMain.GetComponent<CameraController>().shakeAmount = shakeAmount * 0.7f;
                cameraMain.GetComponent<CameraController>().shakeDuration = shakeDuration;
                Destroy(this.gameObject);
            }
        }
        if (other.tag != "Player" && other.tag != "UsedAmmo" && other.tag != "Enemy") {
			if (other.GetComponent<Rigidbody> () != null) {
				
				Rigidbody body = other.gameObject.GetComponent<Rigidbody> ();

				if (body != null && body.isKinematic == false) {
					body.AddForceAtPosition (transform.forward * pushForce, transform.position, ForceMode.Impulse);
				}
			}
			cameraMain.GetComponent<CameraController> ().shakeAmount = shakeAmount * 0.7f;
			cameraMain.GetComponent<CameraController> ().shakeDuration = shakeDuration;
			Destroy (this.gameObject);
			
		}

	}
}
