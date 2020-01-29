using UnityEngine;
using Zenject;

namespace Abilities
{

	public abstract class AbstractAbility:MonoBehaviour
	{
		public int neadMana;
		public float timer;
		public GameObject abilityEffect;

		[Inject]
		protected Ihealth health;
		[Inject]
		protected IMana mana;
		protected bool abilityUse = false;

		public  abstract void UseAbility( );

		protected void AbilityTimer()//метод, который включает и выключает эффекты способностей, еще не дает возможности вызывать
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
