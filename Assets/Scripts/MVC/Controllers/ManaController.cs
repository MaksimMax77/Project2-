using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaController : BaseController
{
	private ManaModel mana;

	public ManaController(ManaModel mana)
	{
		this.mana = mana;
	}

	public override void ControllerUpdate()
	{
		ManaRegen();
	}

	public void ManaRegen()
	{
		if (mana.mana < mana.maxMana)
		{
			mana.mana += 1 * Time.deltaTime;
		}
	}
}
