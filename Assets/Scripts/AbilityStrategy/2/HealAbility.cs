

namespace Abilities
{
	public class HealAbility : AbstractAbility 
	{
	 
		public override void UseAbility()
		{
			if (manaModel.mana >= neadMana && abilityUse == false)
			{
				abilityUse = true;
				healthModel.health += 25;
				manaModel.mana -= neadMana;
			}
		}

		private void Update()
		{
			AbilityTimer();
		}
 
	}
}
