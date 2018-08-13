using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour {
	public static PlayerDamage instance;
	public Animator animator;
	// Use this for initialization
	void Start () {
		instance = this;
	}

	public void PlayAnim()
	{
		animator.SetTrigger("TakeDamage");
	}	
	
}
