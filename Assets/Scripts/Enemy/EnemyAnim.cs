﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public class EnemyAnim : MonoBehaviour
{
	Animator animator;
	CharacterMovement movement;
	[SerializeField] GameObject AnimatorObj;
	EnemyAttack enemyAttack;

	EnemyStateMachine stateMachine;

	private void Awake()
	{
		stateMachine = GetComponent<EnemyStateMachine>();
		animator = AnimatorObj.GetComponent<Animator>();
		movement = GetComponent<CharacterMovement>();
		enemyAttack = GetComponent<EnemyAttack>();
	}
	
	void Update()
    {
		if (movement.WalkSide)
		{
			animator.SetBool("WalkSide", true);
		}
		else if (!movement.WalkSide)
		{
			animator.SetBool("WalkSide", false);
		}

		if (enemyAttack.IsAttack  )
		{
			animator.SetBool("AttackSide", true);
		}
		else if (!enemyAttack.IsAttack )
		{
			animator.SetBool("AttackSide", false);
		}
		if (stateMachine.IsAttack)
		{
			animator.SetBool("AttackSide", true);
		}
		else
		{
			animator.SetBool("AttackSide", false);
		}
	 
	}
}
