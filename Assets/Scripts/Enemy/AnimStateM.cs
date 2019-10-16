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
	Health _health;
	void Awake()
    {
		_health = GetComponent<Health>();
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
		if (_health.death)
		{
			animator.SetBool("Die", true);
		}

	}
}
