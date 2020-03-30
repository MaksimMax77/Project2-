using UnityEngine;
using Zenject;

namespace Abilities
{

	public abstract class AbstractAbility 
	{
		public int neadMana;
		public float timer;
		public GameObject abilityEffect;

		protected bool abilityUse = false;

		public  abstract void UseAbility();

		public abstract void  AbilityUpdate(GameObject abilityEffect);

		protected void AbilityTimer(GameObject abilityEffect)//метод, который включает и выключает эффекты способностей, еще не дает возможности вызывать
			//способность пока не перестанет использоваться текущая способность
		{
			if (abilityUse)
			{
				abilityEffect.SetActive(true);
				timer -= Time.deltaTime;
			}
			if (timer <= 0)
			{
				timer = 2;
				abilityUse = false;
				abilityEffect.SetActive(false);
			}
		}
	}
}
