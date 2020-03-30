using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : BaseController
{
	private HealthModel healthModel;


	public HealthController(HealthModel healthModel)
	{
		this.healthModel = healthModel;
	}


	public override void ControllerUpdate()
	{
		if (healthModel.health <= 0)
		{
			healthModel.death = true;
		}
		if(healthModel.health>= healthModel.maxHealth)
		{
			healthModel.health = healthModel.maxHealth;
		}
	}
}
