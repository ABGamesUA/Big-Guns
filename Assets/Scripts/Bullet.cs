using UnityEngine;

public class Bullet : MonoBehaviour {
	private Transform target;
	public GameObject impactEffect;
	public int damagePower  = 50;
	public float speed = 70f;
	public float explosionRadius = 0f;
	private bool isExploded = false;
	public AudioClip missileSFX;

	public float rate = 1f;
	public float countdownExplode = 5f;
		
	public void Seek(Transform _target){
		target = _target;
	}
	// Update is called once per frame
	void Update () {
		countdownExplode -= Time.deltaTime;	
		if(target == null){				
				float distanceThisFrameNow = speed * Time.deltaTime;
				transform.Translate(Vector3.forward * distanceThisFrameNow, Space.Self);							
				if(isExploded == false && countdownExplode <=0){
					ExplodeEmptyMissile();		
					countdownExplode = 1f/rate;	
					return;							
				}
				countdownExplode -= Time.deltaTime;					
					
		} else{
			
			//Destroy(gameObject);
			//return;
			
		Vector3 dir = target.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;
		if(dir.magnitude <= distanceThisFrame){
			HitTarget();
			return;
		}
			
		transform.Translate(dir.normalized * distanceThisFrame, Space.World);
		transform.LookAt(target);
			}
	}
	

	void HitTarget(){		
		GameObject instEf = (GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
		Destroy(instEf, 5f);
		if(explosionRadius > 0f){
			Explode();
		}else{
			Damage(target);
		}		
	}
	void Explode(){		
		SoundManager.instance.PlayExplodeSFX(missileSFX);
		Collider [] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
		foreach (Collider collider in colliders)
		{
			if(collider.tag == "Enemy"){
				Damage(collider.transform);
			}
			else Destroy(gameObject);
		}
	}
	void Damage(Transform enemy){
		Destroy(gameObject);		
		if(enemy == null) return;
		Enemy e = enemy.GetComponent<Enemy>();
		if (e != null)	e.TakeDamage(damagePower);	
	}

	void ExplodeEmptyMissile(){
		isExploded = true;				
		HitTarget();
	}


	void OnCollisionEnter(Collision other)
	{		
		if(other.gameObject.tag == "Enemy"){
			ExplodeEmptyMissile();
		}
	}
	
}
