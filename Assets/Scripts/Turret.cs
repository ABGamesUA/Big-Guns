using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {
	public AudioSource turretAudio;
	bool isLaser;	
	
	private Transform target;
	public float range = 15f;
	public float turnSpeed = 10f;
	public string enemyTag = "Enemy";
	public Transform partToRotate;
	public Enemy enemyComponent;

	public float fireRate = 1f;
	private float countdownFire = 0f;

[Header ("Use Laser")]
	public bool useLaser = false;
	public LineRenderer lineRender;
	public ParticleSystem impactEffect;
	public Light impactLight;
	public int damageOverTime = 30;  
	public float slowPst = .5f;

	public GameObject bulletPrefab;
	public Transform firePoint;

	private bool isClick = false;

	

	// Use this for initialization
	void Start () {
		InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}

	void UpdateTarget(){
		GameObject [] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;
		foreach (GameObject enemy in enemies)
		{
			float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
			if(distanceToEnemy < shortestDistance){
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}

		if(nearestEnemy != null && shortestDistance <= range){
			target = nearestEnemy.transform;
			enemyComponent = nearestEnemy.GetComponent<Enemy>();
		} else{
			target = null;
		}
		
	}

	void Shoot(){
		turretAudio.Play();
		GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		Bullet bullet = bulletGO.GetComponent<Bullet>();
		if (bullet != null){
			bullet.Seek(target);
		}	
	}
	
	// Update is called once per frame
	void Update () {
		if(target == null){
			if(useLaser){
				if(lineRender.enabled){					
					lineRender.enabled = false;
					impactEffect.Stop();					
					turretAudio.Stop();
					impactLight.enabled = false;
				}
			}
			
			return;
		}
		LockOnTarget();

		if(useLaser){
			Laser();
		} else{
			if(countdownFire <= 0f){
			Shoot();
			countdownFire = 1f/fireRate;
			}
			countdownFire -= Time.deltaTime;
		}
	}

	void Laser(){
		enemyComponent.TakeDamage(damageOverTime * Time.deltaTime);
		enemyComponent.Slow(slowPst);

		if(!lineRender.enabled) {

			lineRender.enabled = true;
			impactEffect.Play();			
			turretAudio.Play();
			impactLight.enabled = true;
		}
		lineRender.SetPosition(0, firePoint.position);
		lineRender.SetPosition(1, target.position);
		Vector3 dir = firePoint.position - target.position;
		impactEffect.transform.position = target.position + dir.normalized;
		impactEffect.transform.rotation = Quaternion.LookRotation(dir);
		
	}

	void LockOnTarget(){
		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation(dir);
		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
		partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
	}	
}
