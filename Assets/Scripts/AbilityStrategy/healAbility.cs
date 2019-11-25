using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealAbility :MonoBehaviour, IAbility
{

	GameObject effectAbility;
	int needMana;
    float timer ;
    bool abilityUse = false;

	Health  playerHealth;
	Mana mana ;
	 

	public HealAbility(GameObject effectAbility, int needMana,Health playerHealth, Mana mana, float timer)
	{
		 this.effectAbility = effectAbility;
		this.needMana = needMana;
		this.playerHealth = playerHealth;
		this.mana = mana;
		this.timer = timer;
	}
	public HealAbility() { }

	public IEnumerator AbbilityTime()
	{
		if (mana.mana >= needMana && abilityUse == false)
		{
			abilityUse = true;
			playerHealth.AddHealth(25);
			effectAbility.SetActive(true);
			mana.TakeMana(needMana);
			yield return new WaitForSeconds(timer);
			abilityUse = false;
			effectAbility.SetActive(false);
		}
		if (abilityUse == true)
		{

			Debug.Log("Скилл уже используется");
		}
		else if (mana.mana < needMana)
		{
			Debug.Log("нехватает маны, петушара");
		}
	}
}
