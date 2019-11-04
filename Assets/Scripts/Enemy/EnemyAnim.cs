using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public class EnemyAnim : MonoBehaviour
{
	Animator animator;
	CharacterMovement movement;
	[SerializeField] GameObject AnimatorObj;
	 

	EnemyStateMachine stateMachine;

	private void Awake()
	{
		stateMachine = GetComponent<EnemyStateMachine>();
		animator = AnimatorObj.GetComponent<Animator>();
		movement = GetComponent<CharacterMovement>();
		 
	}
	
	void Update()
    {
		 
	 
	}
}
