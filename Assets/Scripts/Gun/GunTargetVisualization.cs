using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GunSystem
{

	public class GunTargetVisualization : MonoBehaviour
	{
		[SerializeField] private GameObject player;
		private RedCircleOnnOff redCircle;
		private Aim aim;
		 
	 
	 
		void Awake()
		{
			aim = GetComponent<Aim>();		 
		}

		void Update()
		{
			RedCircleOffOn();
		}

		void RedCircleOffOn()
		{
			
			if (aim.isAiming)
			{
			    redCircle = aim.enemyInTarget.GetComponent<RedCircleOnnOff>();
				redCircle.RedCircleOn = true;
			}

			else
			{
				if (redCircle != null)
				{
					redCircle.RedCircleOn = false;
				}
			}
		}
	}
}
