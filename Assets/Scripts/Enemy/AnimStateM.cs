using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;
public class AnimStateM : MonoBehaviour
{
	public GameObject animatorObj;
	Animator animator;
	[SerializeField]IEnemy currentEnemy;
	CharacterMovement movement;
	Health health;
	void Awake()
    {
		health = GetComponent<Health>();
        movement = GetComponent<CharacterMovement>();
		animator = animatorObj.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		if (currentEnemy.IsAttack == true)
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
		if (health.death)
		{
			animator.SetBool("Die", true);
		}
		if (health.Hit)
		{
			animator.SetBool("Hit", true);
		}
		else if (!health.Hit)
		{
			animator.SetBool("Hit", false);
		}  

	}
}
