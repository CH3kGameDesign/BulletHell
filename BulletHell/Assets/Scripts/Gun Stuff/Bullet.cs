using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public bool playerBullet;
	public bool destroyOnContact;

	public float followEnemyAmount;
	private GameObject nearestEnemy = null;

	public float bulletSpeed = 20;
	public float pushForce = 1;

    public Vector3 shotOrigin;

    public GameObject damageCounter;
    public int damageMin = 2;
	public int damageMax = 2;

	private float preDamage;
	public int damage;

    public float destroyTime = 3;
	public GameObject destroyedBullet;

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

		if (followEnemyAmount != 0) {
			findNearestEnemy ();
		}
    }

















    // Update is called once per frame
	void FixedUpdate () {
		transform.position += transform.forward * Time.deltaTime * bulletSpeed;
		Invoke ("DestroyTime", destroyTime);
		if (followEnemyAmount != 0)
		{
			if (nearestEnemy == null && GameObject.Find ("Enemies").transform.childCount > 0)
				findNearestEnemy ();
			if (nearestEnemy != null) {
				if (GetComponent<UnityEngine.AI.NavMeshAgent> () == null) {
					Quaternion neededRotation = Quaternion.LookRotation (nearestEnemy.transform.position - transform.position);
					transform.rotation = Quaternion.RotateTowards (transform.rotation, neededRotation, Time.deltaTime * followEnemyAmount);
				} else {
					UnityEngine.AI.NavMeshAgent navAgent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
					navAgent.destination = nearestEnemy.transform.position;
				}
			}
		}
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
			if (destroyOnContact)
				DestroyTime ();

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
				if (destroyOnContact)
					DestroyTime ();
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
			DestroyTime ();
			
		}

	}
















	private void findNearestEnemy ()
	{
		List <GameObject> enemies = new List<GameObject>();
		foreach (Transform child in GameObject.Find("Enemies").transform) {
			if (child != GameObject.Find("Enemies").transform) {
				if (child.gameObject.activeSelf == true && (child.position.y > transform.position.y -10 && child.position.y < transform.position.y + 10))
					enemies.Add (child.gameObject);
			}
		}
		float nearestSqrMag = float.PositiveInfinity;
		for(int i = 0; i < enemies.Count; i++)
		{
			float sqrMag = (enemies[i].transform.position - transform.position).sqrMagnitude;
			if(sqrMag < nearestSqrMag)
			{
				nearestSqrMag = sqrMag;
				nearestEnemy = enemies[i];
			}
		}
	}
















	private void DestroyTime ()
	{
		if (destroyedBullet != null) {
			GameObject GO = Instantiate (destroyedBullet, transform.position, transform.rotation);
			//GO.GetComponent<Rigidbody> ().velocity = transform.forward * bulletSpeed / 10;
		}
		Destroy (this.gameObject);
	}
}
