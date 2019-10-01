using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Health Enemyhealth;
	private CharacterMovement _characterMovement;

	bool CanDamage;//если тру то можно нанести типо урон 
	bool facing;//направлен ли персонаж вправо или влево 
	public bool PlayerAttack;// атакует ли персонаж (для анимконтроллера)
	 

	GameObject Enemy;

	[SerializeField] private KeyCode _AttackButton = KeyCode.F;//кнопка которую можно менять в инспекторе
    [SerializeField] int PlayerDamage;
	[SerializeField] GameObject blood;
	[SerializeField] Transform BloodPos;


	void Awake()
	{
		Enemy = GameObject.FindGameObjectWithTag("Enemy");
		Enemyhealth = Enemy.GetComponent<Health>();
		_characterMovement = GetComponent<CharacterMovement>();
	}

	void Update()
	{
		_characterMovement.vecocity = new Vector2(

			Input.GetAxis("Horizontal"),
			Input.GetAxis("Vertical"));
		Attack(_AttackButton);

		if(_characterMovement.vecocity.x > 0 && !facing)
		{
			Flip();
		}
		else if(_characterMovement.vecocity.x < 0 && facing)
		{
			Flip();
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
		if (Input.GetKeyDown(AttackButton))
		{

			StartCoroutine(enumerator());

			if (CanDamage)
			{
				Instantiate(blood, BloodPos.position,Quaternion.identity);
				Destroy(blood, 1);
				Debug.Log("ударил по врагу");
				Enemyhealth.GetDamage(PlayerDamage);
			}
		}
	 	
	}
	#endregion

	#region//всякие тригеры
	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
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
		yield return new WaitForSeconds(0.5f);
		PlayerAttack = false;
	}
}