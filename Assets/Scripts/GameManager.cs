using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public static bool gameEnded;
	public GameObject gameOverUI;
	public GameObject completeLevelUI;	
	public AudioClip levelWin;
	public AudioClip levelLose;

	void Start()
	{
		gameEnded = false;
	}
	// Update is called once per frame
	void Update () {
		if(PlayerStats.lives <= 0){
			if(!gameEnded) EndGame();
		}
		
	}

	void EndGame(){	
		SoundManager.instance.PlayEventSFX(levelLose);	
		gameEnded = true;
		gameOverUI.SetActive(true);
	}

	public void WinLevel(){
		SoundManager.instance.PlayEventSFX(levelWin);
		gameEnded = true;
		completeLevelUI.SetActive(true);
	}
}
