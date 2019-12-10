using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerController : MonoBehaviour
{
	 
	Health plaHealth;
	private CharacterMovement characterMovement;
 	bool isfacing;//направлен ли персонаж вправо или влево 
	CharBehavior charBehavior;// атакует ли персонаж (для анимконтроллера)
	 
	ButtonManager buttonManager;
	 
 
	void Awake()
	{
		charBehavior = GetComponent<CharBehavior>();
		buttonManager = GetComponent<ButtonManager>();
		 plaHealth = GetComponent<Health>();
		characterMovement = GetComponent<CharacterMovement>();
	}

	void Update()
	{
		if (plaHealth.death == false)//шоб обездвижить если умер 
		{
			characterMovement.vecocity = new Vector2(

				Input.GetAxis("Horizontal"),
				Input.GetAxis("Vertical"));
			Attack(buttonManager.attackButton);

			if (characterMovement.vecocity.x > 0 && !isfacing)
			{
				Flip();
			}
			else if (characterMovement.vecocity.x < 0 && isfacing)
			{
				Flip();
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


	#region//метод атаки
	/// <summary>
	/// метод атаки
	/// </summary>
	/// <param name="кнопка удара"></param>
	void Attack(KeyCode AttackButton)
	{
		 
		if (Input.GetKeyDown(AttackButton)&& charBehavior.IsAttack == false)
		{

             StartCoroutine(Enumerator());
		}	
	}
	#endregion

	 
	IEnumerator Enumerator()
	{
		charBehavior.IsAttack = true;
		yield return new WaitForSeconds(0.3f);
		charBehavior.IsAttack = false;
	}
}