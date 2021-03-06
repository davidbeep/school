﻿using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour 
{
	private static MusicManager _instance;
	private static bool soundEffects = true ;
	
	public static MusicManager instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = GameObject.FindObjectOfType<MusicManager>();
		
				//Tell unity not to destroy this object when loading a new scene!
				DontDestroyOnLoad(_instance.gameObject);
			}
			
			return _instance;
		}
	}
	
	void Awake() 
	{
		if(_instance == null)
		{
			//If I am the first instance, make me the Singleton
			_instance = this;

			DontDestroyOnLoad(this);
			Play() ;
		}
		else
		{
			//If a Singleton already exists and you find
			//another reference in scene, destroy it!
			if(this != _instance)
				Destroy(this.gameObject);
		}
	}
	
	public void Play()
	{
		//Play some audio!
		this.gameObject.GetComponent<AudioSource>().Play ();
	}
	public void Pause()
	{
		this.gameObject.GetComponent<AudioSource>().Pause ();
	}
	public void UnPause()
	{
		this.gameObject.GetComponent<AudioSource> ().UnPause ();
	}
	public bool IsPlaying()
	{
		return this.gameObject.GetComponent<AudioSource> ().isPlaying ;
	}
	public void EnableSoundEffects()
	{
		soundEffects = true;
	}
	public void DisableSoundEffects()
	{
		soundEffects = false;
	}

	// NOTE: This method must be called on the singleton instance before playing any sound effect. To check if user had 
	// soundfx enabled or disabled
	public bool SoundEffectsOn()
	{
		return soundEffects ; // true if sfx are on, false if otherwise
	}
}
