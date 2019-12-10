using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class AbstractAbility : MonoBehaviour
{
    public int neadMana;
    public float timer;
    public GameObject abilityEffect;

	[Inject]
	protected  Ihealth health;
	[Inject]
	protected  IMana mana;
	protected bool abilityUse=false;

	

	protected void AbilityTimer ()
	{
		if (abilityUse)
		{
			abilityEffect.SetActive(true);
			timer -= Time.deltaTime;
		}
		if (timer <= 0)
		{
			timer = 2;
			abilityUse = false;
			abilityEffect.SetActive(false);
		}
	}
}
