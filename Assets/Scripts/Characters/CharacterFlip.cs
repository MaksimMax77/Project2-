using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class CharacterFlip : MonoBehaviour
{
	private Health charHealth;
	private CharacterMovement characterMovement;
	[SerializeField] bool isfacing;//направлен ли персонаж вправо или влево
	[SerializeField] private string characterGunTag;
	[SerializeField] private bool isCharacterWithGun;// если персонаж с пушкой то надо это чекнуть в инспекторе.

	private Aim aim;

	void Awake()
	{
		charHealth = GetComponent<Health>();
		characterMovement = GetComponent<CharacterMovement>();
		if (isCharacterWithGun)
		{
			var Gun = GameObject.FindGameObjectWithTag(characterGunTag);
			aim = Gun.GetComponent<Aim>();
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
