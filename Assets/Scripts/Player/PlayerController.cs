﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Health Enemyhealth;
	Health Plahealth;
	private CharacterMovement _characterMovement;

	public bool CanDamage;//если тру то можно нанести типо урон 
	bool facing;//направлен ли персонаж вправо или влево 
	public bool PlayerAttack;// атакует ли персонаж (для анимконтроллера)

	[SerializeField] Weapon currentWeapon;
	 
	GameObject Enemy;
	 
	[SerializeField] private KeyCode _AttackButton = KeyCode.F;//кнопка которую можно менять в инспекторе
	[SerializeField] GameObject blood;
	[SerializeField] Transform BloodPos;


	void Awake()
	{
	 
		Plahealth = GetComponent<Health>();
		Enemy = GameObject.FindGameObjectWithTag("Enemy");
		_characterMovement = GetComponent<CharacterMovement>();
	}

	void Update()
	{
		if (Plahealth.death == false)//шоб обездвижить если умер 
		{
			_characterMovement.vecocity = new Vector2(

				Input.GetAxis("Horizontal"),
				Input.GetAxis("Vertical"));
			Attack(_AttackButton);

			if (_characterMovement.vecocity.x > 0 && !facing)
			{
				Flip();
			}
			else if (_characterMovement.vecocity.x < 0 && facing)
			{
				Flip();
			}
		}
	}

	 

	private void Flip()
	{
		facing = !facing;
		Vector3 theScale = transform.localScale;  
		 theScale.x *= -1;
		 transform.localScale = theScale; 
	}


	#region//метод атаки
	/// <summary>
	/// метод атаки
	/// </summary>
	/// <param name="кнопка удара"></param>
	void Attack(KeyCode AttackButton)
	{
		AttackButton = _AttackButton;
		if (Input.GetKeyDown(AttackButton)&&PlayerAttack==false)
		{
             StartCoroutine(enumerator());

			if (CanDamage)
			{
				if (PlayerAttack == true)
				{   
				Instantiate(blood, BloodPos.position, Quaternion.identity);
				currentWeapon.Attack(Enemyhealth);
				}
			}
		}	
	}
	#endregion

	#region//всякие тригеры
	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Enemy"  )
		{
			Enemyhealth = collision.GetComponent<Health>();
			CanDamage = true;
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
			CanDamage = false;
		}
	}
	#endregion
	IEnumerator enumerator()
	{
		PlayerAttack = true;
		yield return new WaitForSeconds(0.6f);
		PlayerAttack = false;
	}
}