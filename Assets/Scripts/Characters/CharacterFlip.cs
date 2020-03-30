using System;
using System.Collections;
using System.Collections.Generic;
using GunSystem;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class CharacterFlip : MonoBehaviour
{
	private HealthModel charHealth;
	private CharacterMovementModel characterMovement;
	[SerializeField] bool isfacing;//направлен ли персонаж вправо или влево
	[SerializeField] private int characterGunPos;
	[SerializeField] private bool isCharacterWithGun;// если персонаж с пушкой то надо это чекнуть в инспекторе.

	private Aim aim;

	void Awake()
	{
		charHealth = GetComponent<HealthModel>();
		characterMovement = GetComponent<CharacterMovementModel>();
		if (isCharacterWithGun)
		{
			//var Gun = GameObject.FindGameObjectWithTag(characterGunTag);
			aim = gameObject.transform.GetChild(characterGunPos).GetComponent<Aim>();
			//aim = Gun.GetComponent<Aim>();
		}
	}

	void Update()
	{
		if(isCharacterWithGun) FlipToEnemySide();

		if (charHealth.death == false)//шоб обездвижить если умер 
		{
			FlipToDirection();
		}
	}

	private void FlipToDirection()
	{
		if (characterMovement.vecocity.x > 0 && !isfacing)
		{
			if (isCharacterWithGun)
			{
				if (!aim.isAiming)
					Flip();
			}
			else
			{
				Flip();
			}
		}

		if (characterMovement.vecocity.x < 0 && isfacing)
		{
			if (isCharacterWithGun)
			{
				if (!aim.isAiming)
					Flip();
			}
			else
			{
				Flip();
			}
		}
	}

	private void FlipToEnemySide()
	{
		
		if (aim.isAiming)
		{
			if (isfacing)
			{
				if (aim.enemyInTarget.transform.position.x < transform.position.x)
				{
					Flip();
				}
			}

			if (!isfacing)
			{
				if (aim.enemyInTarget.transform.position.x > transform.position.x)
				{
					Flip();
				}
			}
		}
	}


	private void Flip()
	{
		isfacing = !isfacing;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
