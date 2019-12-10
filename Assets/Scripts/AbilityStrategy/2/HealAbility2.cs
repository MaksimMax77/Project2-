using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealAbility2 : AbstractAbility,IAbbility2
{
	ButtonManager buttonManager;

	public void UseAbility()
	{
		if (mana.mana >= neadMana && abilityUse == false)
		{
			abilityUse = true;
			health.AddHealth(25);
			mana.TakeMana(neadMana);
		}
	}

	void Awake()
	{
		buttonManager = GetComponent<ButtonManager>();
	}

	void Update()
	{
		AbilityTimer();
	 if (Input.GetKeyDown(buttonManager.useAbilityButton))
		 {
		 	UseAbility();
		 }
	}
}
