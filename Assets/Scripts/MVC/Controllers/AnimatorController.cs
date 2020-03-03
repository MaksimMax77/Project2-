using MyAnimator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController: BaseController
{
	IAnimate animate;
	AnimatorModel animatorModel;
	GameObject  gameObject;

	public AnimatorController(AnimatorModel animatorModel, GameObject gameObject )
	{
		this.animatorModel = animatorModel;
		this.gameObject = gameObject;
		CreateAnimatorObj();
	}

	public override void ControllerUpdate()
	{
		animate.AnimateObj();
	}

	IAnimate CreateAnimatorObj()
	{
		 
			if (animatorModel.isPlayerAnimator)
			{
				animate = new AnimatePlayer();
				animate.AnimatorStart(gameObject);
			}
			if (animatorModel.isEnemyAnimator)
			{
				animate = new AnimateEnemy();
				animate.AnimatorStart(gameObject);
			}

			if (animatorModel.isWizardEnemy)
			{
				animate = new AnimateWizard();
				animate.AnimatorStart((gameObject));
			}
		 
		return animate;
	}
}
