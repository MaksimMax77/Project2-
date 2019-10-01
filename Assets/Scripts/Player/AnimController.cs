using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
	Animator animator;
	CharacterMovement movement;
	PlayerController player;
	Health health;
	[SerializeField] GameObject AnimatorObj;
	 
    void Awake()
    {
		 
		health = GetComponent<Health>();
		animator = AnimatorObj.GetComponent<Animator>();
		movement = GetComponent<CharacterMovement>();
		player = GetComponent<PlayerController>();
    }

    
    void Update()
    {
		if (movement.WalkSide )
		{
			animator.SetBool("WalkSide", true);
		}
		else if(!movement.WalkSide )
		{
			animator.SetBool("WalkSide", false);
		}
		 
		if (player.PlayerAttack)
		{
			animator.SetBool("AttackSide", true);
		}
		else if (!player.PlayerAttack)
		{
				animator.SetBool("AttackSide", false);	 
		}
		if (health.death)
		{
			animator.SetBool("Die", true);
		}
		else if (!health.death)
		{
			animator.SetBool("Die", false);
		}

	 
	}
}
