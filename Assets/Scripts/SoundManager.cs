using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
	public static SoundManager instance;
	public AudioSource musicBG;
	public AudioSource clickPlay;
	public AudioSource expplodeAS;
	public AudioSource gameEvents;
	public AudioClip track_1;	
	public AudioClip track_2;
	AudioClip nextTrack;

	private void Awake()
	{
		if(instance == null) instance = this;
		else if (instance != this) Destroy(gameObject);
		DontDestroyOnLoad(gameObject);
		musicBG.clip = track_1;
		nextTrack = track_2;
		musicBG.Play();
	}

	private void Update()
	{
		if(!musicBG.isPlaying)
		{
			musicBG.clip = nextTrack;
			if(nextTrack == track_1) nextTrack = track_2;
			else if(nextTrack == track_2)nextTrack = track_1;
			musicBG.Play();			
		}
	}

	public void PlayClickSFX()
	{
		clickPlay.Play();
	}

	public void PlayEventSFX(AudioClip clip)
	{
		gameEvents.clip = clip;
		gameEvents.Play();
	}

	public void PlayExplodeSFX(AudioClip clip)
	{
		expplodeAS.clip = clip;
		expplodeAS.Play();
	}
}
