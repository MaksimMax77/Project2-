using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager1  
{
	AudioSource audioSource;
	private   float musicVolume, soundVolume;
	private static bool muteMusic, muteSound;
 
 


	public SoundManager1(AudioSource audioSource)
	{
		this.audioSource = audioSource;
	}

	public void PlaySound(AudioClip audioClip,float soundVolume)
	{
		this.soundVolume = soundVolume;
		audioSource.PlayOneShot(audioClip, soundVolume);
	}

	public void SetMutesound()
	{
		muteSound = true;
		if(muteSound)
		soundVolume = 0;
	}

	 
}
