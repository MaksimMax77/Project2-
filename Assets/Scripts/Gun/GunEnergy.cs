using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GunSystem
{

	public class GunEnergy : MonoBehaviour
	{
		public bool isInfiniteGunEnergy;
		public float gunEnerdy;

		void Update()
		{
			if (gunEnerdy > 100)
			{
				gunEnerdy = 100;
			}
		}
	}
}
