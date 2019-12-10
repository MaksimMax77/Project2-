using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MYSoundManager : MonoBehaviour
{
	[SerializeField]  AudioClip _audioAttack;
	[SerializeField] AudioClip _audioSteps;
	[SerializeField] AudioClip _audioHit;

	[SerializeField] float _volume;
	[SerializeField] bool Istepping;//для шагов
	AudioSource _audioSource;

	PlayerController playerController;
	CharacterMovement characterController;
	 
	void Start()
    {
		_audioSource = GetComponent<AudioSource>();
		var Player = GameObject.FindGameObjectWithTag("Player");
		playerController = Player.GetComponent<PlayerController>();
		characterController = Player.GetComponent<CharacterMovement>();
		 
	}

	private void Update()
	{
		PlaySteps();

		if (Input.GetKeyDown(KeyCode.F))
		{
			PlayAudio(_audioAttack);
		}
	}


	public	void PlayAudio(AudioClip audioClip )
	{
		_audioSource.PlayOneShot(audioClip, _volume );
	}


	void PlaySteps()
	{
		if (Istepping == false)
		{
			if (characterController.vecocity.x != 0 || characterController.vecocity.y != 0) 
			{
				StartCoroutine(EnumeratorSteps());
			}
		}
	}


	IEnumerator EnumeratorSteps()//для шагов
	{
		Istepping = true;
		PlayAudio(_audioSteps);
		yield return new WaitForSeconds(0.3f);
		Istepping = false;
	}
}
