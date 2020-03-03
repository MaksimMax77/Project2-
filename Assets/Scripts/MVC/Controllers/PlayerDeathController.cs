using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathController : BaseController
{
	 
	private PlayerDeathModel playerDeathModel;
	private PlayerDeathView playerDeathView;

	public PlayerDeathController(PlayerDeathModel playerDeathModel, PlayerDeathView playerDeathView)
	{
		this.playerDeathModel = playerDeathModel;
		this.playerDeathView = playerDeathView;
	}

	public override void ControllerUpdate()
	{
		DeathScreenOffOn();
	}

	void DeathScreenOffOn()
	{
		if (playerDeathModel.health.death)
		{
			playerDeathView.DeathOn();
		}
		else
		{
			playerDeathView.DeathOff();
		}
	}

 

}
