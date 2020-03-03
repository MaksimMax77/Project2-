using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : BaseController
{
	private HealthModel healthModel;
	private MonoBehaviour monoBehaviour;

	public HealthController(HealthModel healthModel)
	{
		monoBehaviour = new MonoBehaviour();
		this.healthModel = healthModel;
	}


	public override void ControllerUpdate()
	{
		if (healthModel.health <= 0)
		{
			healthModel.death = true;
		}
	}
}
