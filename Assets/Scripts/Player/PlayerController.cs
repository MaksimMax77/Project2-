using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    
	Health Plahealth;
	private CharacterMovement _characterMovement;

 	bool facing;//направлен ли персонаж вправо или влево 
	public bool PlayerAttack;// атакует ли персонаж (для анимконтроллера)
	ButtonManager buttonManager;
	 
	 
	void Awake()
	{
		buttonManager = GetComponent<ButtonManager>();
		   Plahealth = GetComponent<Health>();
		_characterMovement = GetComponent<CharacterMovement>();
	}

	void Update()
	{
		if (Plahealth.death == false)//шоб обездвижить если умер 
		{
			_characterMovement.vecocity = new Vector2(

				Input.GetAxis("Horizontal"),
				Input.GetAxis("Vertical"));
			Attack(buttonManager.AttackButton);

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
		 
		if (Input.GetKeyDown(AttackButton)&&PlayerAttack==false)
		{
             StartCoroutine(enumerator());
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