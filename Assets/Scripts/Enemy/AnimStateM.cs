using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;
public class AnimStateM : MonoBehaviour
{
	public GameObject _animatorObj;
	Animator animator;
	EnemyStateMachine enemy;
	CharacterMovement movement;
	
	void Awake()
    {
        movement = GetComponent<CharacterMovement>();
		enemy = GetComponent<EnemyStateMachine>();
		animator = _animatorObj.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		if (enemy.IsAttack == true)
		{
			animator.SetBool("AttackSide", true);
		}
		else
		{
			animator.SetBool("AttackSide", false);
		}
		if (movement.WalkSide)
		{
			animator.SetBool("WalkSide", true);
		}
		else if (!movement.WalkSide)
		{
			animator.SetBool("WalkSide", false);
		}

	}
}
