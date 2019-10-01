using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum AiState
{
    Attack,
    Patrol,
}

public class EnemyAi : MonoBehaviour
{
	[SerializeField] Transform target;
	[SerializeField] float _StopDistance;

	private CharacterMovement _characterMovement;
	private Health Enemyhealth;

	private bool IsStop;
	public bool patrol;// хрень для энемимув
    private AiState currentState;

	private void Awake()
	{
		_characterMovement = GetComponent<CharacterMovement>();
		Enemyhealth = GetComponent<Health>();
		patrol = true;
	}

	private void Update()
	{
		if (Enemyhealth.death == true)
		{
			Destroy(gameObject);
		}
		if (IsStop == false && patrol==false)
		{
            _characterMovement.vecocity = target.position - transform.position;
		}
		else if (IsStop == true)
		{
			_characterMovement.vecocity = new Vector2(0, 0);
		}
	 
		float distance = Vector3.Distance(target.position, transform.position);
		if(distance> _StopDistance && distance < 15f)
		{ 
			IsStop = false;
			patrol = false;
		}
		else
		{
			patrol = true;
		}
		if (distance < _StopDistance)
		{
			IsStop = true;
		}
	}
}
