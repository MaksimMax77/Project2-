using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterMovement _characterMovement;
    bool CanDamage;//если тру то можно нанести типо урон 

	[SerializeField] private KeyCode _AttackButton = KeyCode.F;//кнопка которую можно менять в инспекторе

	void Awake()
    {
        _characterMovement = GetComponent<CharacterMovement>(); 
    }

    void Update()
    {
        _characterMovement.vecocity = new Vector2(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical"));
		    Attack(_AttackButton);  
    }


	#region//метод атаки
	/// <summary>
	/// метод атаки
	/// </summary>
	/// <param name="кнопка удара"></param>
	void Attack(KeyCode  AttackButton)
	{
		 AttackButton = _AttackButton;
		if (Input.GetKeyDown(AttackButton))
		{

			if (CanDamage)
			{
				Debug.Log("ударил по врагу");
			}
			else
			{
				Debug.Log("ударил мимо");
			}
		}
	}
	#endregion

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
}
	 
 
