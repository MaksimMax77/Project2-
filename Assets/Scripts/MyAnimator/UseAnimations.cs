using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyAnimator
{
	public class UseAnimations : MonoBehaviour
	{
		IAnimate animate;
		[SerializeField] bool isPlayerAnimator;
		[SerializeField] bool isEnemyAnimator;
		[SerializeField] private bool isWizardEnemy;


		void Awake()
		{
			CreateAnimatorObj();
		}

		void Update()
		{
			animate.AnimateObj();
		}

		IAnimate CreateAnimatorObj()
		{
			if (isPlayerAnimator)
			{
				animate = new AnimatePlayer();
				animate.AnimatorStart(this.gameObject);
			}
			if (isEnemyAnimator)
			{
				animate = new AnimateEnemy();
				animate.AnimatorStart(this.gameObject);
			}

			if (isWizardEnemy)
			{
				animate=new AnimateWizard();
				animate.AnimatorStart((this.gameObject));
			}
			return animate;
		}
	}
}
