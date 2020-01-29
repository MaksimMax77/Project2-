using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class MusicManagerComponent : MonoBehaviour
{ 
	[SerializeField] string music;


	private void OnEnable()
	{
		PlayMusic(music);
	}

 
	public void PlayMusic(string name)
	{
		MusicManager.PlayMusic(name, true);
	}
 
	public void MusicVolume(float volume)
	{
		MusicManager.MusicVolume(volume);
	}

	public void ToggleMusicMuted(bool value)
	{
		MusicManager.MuteMusic(!value);
	}
}
