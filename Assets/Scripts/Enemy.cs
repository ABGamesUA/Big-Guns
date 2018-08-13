using UnityEngine.UI;
using UnityEngine;

public class Enemy : MonoBehaviour {
	 [HideInInspector]
	 public float speed;
	 public float startSpeed = 10f;
	 public float startHealth = 100f;
	 private float health;	
	 public int getMoneyCount = 50;	 
	 private bool isDead = false;
	 public AudioSource takeHit;

	 public GameObject deathEffect;	
	 [Header("Unity Stuff")]
	 public Image healthBar;


	void Start(){
		WaweSpawner.enemiesAlive++;
		speed = startSpeed;
		health = startHealth;
	}

	 public void TakeDamage (float amount){
		// takeHit.Play();
		 health = health - amount;
		 healthBar.fillAmount = health / startHealth;	
			if(health <= 0 && !isDead){
				Die();
	 		} 
	 }

	 public void Slow(float pct){
		speed = startSpeed *(1f-pct);
	 }

	void Die(){
		isDead = true;		
		PlayerStats.money += getMoneyCount;
		GameObject de = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
		WaweSpawner.enemiesAlive--;
		Destroy(gameObject);
		Destroy(de, 5f);
	}
}
