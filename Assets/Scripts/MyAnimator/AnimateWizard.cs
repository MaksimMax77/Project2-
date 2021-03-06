﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyAnimator
{
	public class AnimateWizard : IAnimate
	{
		private CharBehavior charBehavior;
		private Animator animator;
		HealthModel healthModel;

		public override void AnimatorStart(GameObject gameObject)
		{
			charBehavior = gameObject.GetComponent<CharBehavior>();
			animator = gameObject.GetComponent<Animator>();
			healthModel = gameObject.GetComponent<HealthModel>();
		}

		public override void AnimateObj()
		{
			if (charBehavior.IsAttack)
			{
				animator.SetBool("AttackSide", true);
			}
			else
			{
				animator.SetBool("AttackSide", false);
			}
	
		}
	}
}
