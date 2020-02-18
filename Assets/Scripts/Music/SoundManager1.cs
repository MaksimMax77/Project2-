using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sound
{

	public class SoundManager1
	{
		AudioSource audioSource;
		public bool needPlayBattleMusic;
		private float musicVolume, soundVolume;
		private static bool muteMusic, muteSound;



		public SoundManager1()
		{
		}

		public SoundManager1(AudioSource audioSource)
		{
			this.audioSource = audioSource;
		}

		public void PlaySound(AudioClip audioClip, float soundVolume)
		{
			this.soundVolume = soundVolume;
			audioSource.PlayOneShot(audioClip, soundVolume);
		}

		public void SetMutesound()
		{
			muteSound = true;
			if (muteSound)
				soundVolume = 0;
		}

		public void PlayMusic(AudioClip fonMusic, AudioClip battleMusic)
		{
			//audioSource.playOnAwake = true;
			audioSource.loop = true;

			if (needPlayBattleMusic)
			{
				audioSource.PlayOneShot(battleMusic);
			}
			else if (!needPlayBattleMusic)
			{
				audioSource.PlayOneShot(fonMusic);
			}
		}
	}
}