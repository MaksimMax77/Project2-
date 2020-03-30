using Abilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseAbilityController : BaseController 
{
	private ButtonManager buttonManager;
	private UseAbilityModel abilityModel;
	private HealAbility healAbility;
	private ImpulsAbility impulsAbility;

	public UseAbilityController(ButtonManager buttonManager, UseAbilityModel abilityModel, GameObject character)
	{
		this.buttonManager = buttonManager;
		this.abilityModel = abilityModel;
		healAbility = new HealAbility(character.GetComponent<HealthModel>(), character.GetComponent<ManaModel>());
		impulsAbility = new ImpulsAbility(character, character.GetComponent<ManaModel>());
		 
	}

	public override void ControllerUpdate()
	{
		healAbility.neadMana = abilityModel.needManaToHeal;
		impulsAbility.neadMana = abilityModel.needManaToImpuls;
		abilityModel.impulsDamage = impulsAbility.damage;
		abilityModel.impulsDamageType = impulsAbility.damageType;

		impulsAbility.AbilityUpdate(abilityModel.impulsEffect);
		healAbility.AbilityUpdate(abilityModel.healEffect);

		if (Input.GetKeyDown(buttonManager.useAbilityButton))
		{
			healAbility.UseAbility();

		}

		if (Input.GetKeyDown(buttonManager.useAbilityButton3))
		{
			impulsAbility.UseAbility();
		}
	}
}
