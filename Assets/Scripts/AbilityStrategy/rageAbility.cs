using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageAbility : MonoBehaviour,IAbility
{
	GameObject effectAbility;
	int needMana;
	float timer;
	public bool abilityUse = false;

	Mana mana;
	Sword weapon = new Sword();
	public RageAbility(GameObject effectAbility, int needMana,  Mana mana, float timer  )
	{
		this.effectAbility = effectAbility;
		this.needMana = needMana;
		this.mana = mana;
		this.timer = timer;
		 
	}
	public RageAbility()
	{

	}
 
	public IEnumerator AbbilityTime()
	{
		if (mana.mana >= needMana && abilityUse == false)
		{
            abilityUse = true;
			effectAbility.SetActive(true);
			mana.TakeMana(needMana);
			weapon.damage = 30;
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
