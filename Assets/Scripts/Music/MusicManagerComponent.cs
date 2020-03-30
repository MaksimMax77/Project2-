using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Sound
{

	public class MusicManagerComponent : MonoBehaviour
	{
		[SerializeField] string music;
		[SerializeField] private AudioClip audioClip;
		[SerializeField] private AudioSource audioSource;


		private void OnEnable()
		{
			MyPlayMusic();
		}

		void MyPlayMusic()
		{
			audioSource.clip = audioClip;
			audioSource.Play();
		}
	}
}
