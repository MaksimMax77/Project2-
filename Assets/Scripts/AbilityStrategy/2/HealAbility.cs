

namespace Abilities
{
	public class HealAbility : AbstractAbility 
	{

		public override void UseAbility()
		{
			if (mana.mana >= neadMana && abilityUse == false)
			{
				abilityUse = true;
				health.AddHealth(25);
				mana.TakeMana(neadMana);
			}
		}

		private void Update()
		{
			AbilityTimer();
		}
 
	}
}
