using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAi : MonoBehaviour
{
	[SerializeField] Transform target;
    public 	bool Patrol;
	bool IsAttack;

	[SerializeField] float _distance;

	private CharacterMovement _characterMovement;
	private Health Enemyhealth;
	 
	private void Awake()
	{
		_characterMovement = GetComponent<CharacterMovement>();
		Enemyhealth = GetComponent<Health>();
		 

	}

	private void Update()
	{
		if (Enemyhealth.death == true)
		{
			Destroy(gameObject);
		}
	 
		if (Patrol == false)
		{
           _characterMovement.vecocity = target.position - transform.position;
			float distance = Vector3.Distance(target.position, transform.position);
			if (distance < 1.5f)
			{
				Debug.Log("говно");
				_characterMovement.speed = 0;
			}
		 
		}
	}

 

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			Patrol = false;
		}

	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			Patrol = true;
		}

	}
}
