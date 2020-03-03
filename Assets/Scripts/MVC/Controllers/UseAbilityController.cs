using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseAbilityController : BaseController 
{
	private ButtonManager buttonManager;
	private UseAbilityModel abilityModel;

	public UseAbilityController(ButtonManager buttonManager, UseAbilityModel abilityModel)
	{
		this.buttonManager = buttonManager;
		this.abilityModel = abilityModel;
	}

	public override void ControllerUpdate()
	{
		if (Input.GetKeyDown(buttonManager.useAbilityButton))
		{
			abilityModel.healAbility2.UseAbility();

		}

		if (Input.GetKeyDown(buttonManager.useAbilityButton3))
		{
			abilityModel.impulsAbility2.UseAbility();
		}
	}
}
