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


	private Aim aim;

	void Awake()
	{
		charHealth = GetComponent<Health>();
		characterMovement = GetComponent<CharacterMovement>();
		var Gun = GameObject.FindGameObjectWithTag(characterGunTag);
		aim = Gun.GetComponent<Aim>();
	}

	void Update()
	{
		if(aim!=null) FlipToEnemySide();

		if (charHealth.death == false)//шоб обездвижить если умер 
		{

			if (characterMovement.vecocity.x > 0 && !isfacing)
			{
				if (!aim.isAiming)
					Flip();
				if (aim==null)
				{
					Flip();
				}
				 
			}
			else if (characterMovement.vecocity.x < 0 && isfacing)
			{
				if (!aim.isAiming)
					Flip();
				if (aim == null)
				{
					Flip();
				}
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
