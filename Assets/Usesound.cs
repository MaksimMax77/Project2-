using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Usesound : MonoBehaviour
{
	[SerializeField] private bool Istepping;//для шагов
	private ButtonManager buttonManager;
	CharacterMovementModel characterMovement;


	void Start()
	{
		var Player = GameObject.FindGameObjectWithTag("Player");
		buttonManager = Player.GetComponent<ButtonManager>();
		characterMovement = Player.GetComponent<CharacterMovementModel>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(buttonManager.attackButton))
		{
			//SoundManager1.PlaySound("AttackSound");
		}
		if (Input.GetKeyDown(buttonManager.useAbilityButton))
		{
			//SoundManager1.PlaySound("UseAbility");
		}
		PlaySteps();
	}

	IEnumerator EnumeratorSteps()//для шагов
	{
		Istepping = true;
		//SoundManager1.PlaySound("StepsSound");
		yield return new WaitForSeconds(0.3f);
		Istepping = false;
	}

	void PlaySteps()
	{
		if (Istepping == false)
		{
			if (characterMovement.vecocity.x != 0 || characterMovement.vecocity.y != 0)
			{
				StartCoroutine(EnumeratorSteps());
			}
		}
	}

}
