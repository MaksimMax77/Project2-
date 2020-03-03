using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sound
{

	public class CharacterSound : MonoBehaviour
	{
		[SerializeField] AudioSource audioSource;
		[SerializeField] AudioClip audioSteps;
		[SerializeField] AudioClip audioShoot;
		bool Istepping;
		bool IsShooting;
		public float soundVolume;
		SoundManager1 soundManager;

		CharBehavior charBehavior;
		CharacterMovementModel characterMovement;

		private void Awake()
		{
			charBehavior = GetComponent<CharBehavior>();
			characterMovement = GetComponent<CharacterMovementModel>();
			audioSource = audioSource.GetComponent<AudioSource>();
			soundManager = new SoundManager1(audioSource);
		}


		private void Update()
		{
			PlaySteps();
			UseAttackSound();
		}


		void UseAttackSound()
		{

			if (charBehavior.IsAttack)
			{
				if (IsShooting == false)
				{
					StartCoroutine(EnumeratorShoot());
					soundManager.PlaySound(audioShoot, soundVolume);
				}
			}
		}

		#region steps

		void PlaySteps() //шаги
		{
			if (Istepping == false)
			{
				if (characterMovement.vecocity.x != 0 || characterMovement.vecocity.y != 0)
				{
					StartCoroutine(EnumeratorSteps());
				}
			}
		}


		public IEnumerator EnumeratorSteps() //для шагов
		{
			Istepping = true;
			soundManager.PlaySound(audioSteps, soundVolume);
			yield return new WaitForSeconds(0.3f);
			Istepping = false;
		}

		#endregion

		public IEnumerator EnumeratorShoot() //для стрельбы
		{
			IsShooting = true;
			yield return new WaitForSeconds(0.3f);
			IsShooting = false;
		}
	}
}
