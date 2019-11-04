using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseAbility : MonoBehaviour
{
	 
	[SerializeField] GameObject HealAbbilityEffect;
	[SerializeField] GameObject RageAbbilityEffect;

	

	[SerializeField]int NeadMana;
	[SerializeField] float timer;

	Health health;
	Mana _mana;
    ButtonManager buttonManager;
	healAbility healAbility;
	rageAbility rageAbility;
 
	 
	void Start()
    {
		buttonManager = GetComponent<ButtonManager>();
		   health = GetComponent<Health>();
		_mana = GetComponent<Mana>();
		healAbility = new healAbility(HealAbbilityEffect, NeadMana, health, _mana,timer );
		rageAbility = new rageAbility(RageAbbilityEffect, NeadMana, _mana, timer);
	 
	}

    // Update is called once per frame
    void Update()
    {
		if(Input.GetKeyDown(buttonManager.UseAbilityButton))
		{
          DoAbility(healAbility);	 
		}
		if (Input.GetKeyDown(buttonManager.UseAbilityButton2))
		{
			DoAbility(rageAbility);
		}
	}

	void DoAbility(IAbility ability)
	{ 
		 StartCoroutine(ability.AbbilityTime());
	}
}
