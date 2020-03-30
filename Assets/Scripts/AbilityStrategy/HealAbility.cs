using UnityEngine;

namespace Abilities
{
	 

	public class HealAbility : AbstractAbility 
	{

		private HealthModel healthModel;
		private ManaModel manaModel;

		public HealAbility(HealthModel healthModel, ManaModel manaModel)
		{
			this.manaModel = manaModel;
			this.healthModel = healthModel;
		}

		public override void UseAbility()
		{
			if (manaModel.mana >= neadMana && abilityUse == false)
			{
				abilityUse = true;
				healthModel.health += 25;
				manaModel.mana -= neadMana;
			}
		}

		public override void AbilityUpdate(GameObject abilityEffect)
		{
			AbilityTimer(abilityEffect);
		}
 
	}
}
