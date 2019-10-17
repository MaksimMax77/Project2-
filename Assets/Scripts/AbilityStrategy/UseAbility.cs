using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseAbility : MonoBehaviour
{

	[SerializeField] private KeyCode _abilityHealButton = KeyCode.Q;
	[SerializeField] private KeyCode _abilityRageButton = KeyCode.R; 

	[SerializeField] GameObject HealAbbilityEffect;
	[SerializeField] GameObject RageAbbilityEffect;
	 

	[SerializeField]int NeadMana;
	[SerializeField] float timer;
	Health health;
	Mana _mana;
	 

	healAbility healAbility;
	rageAbility rageAbility;
 
	 
	void Start()
    {
	 
		health = GetComponent<Health>();
		_mana = GetComponent<Mana>();
		healAbility = new healAbility(HealAbbilityEffect, NeadMana, health, _mana,timer );
		rageAbility = new rageAbility(RageAbbilityEffect, NeadMana, _mana, timer);
	 
	}

    // Update is called once per frame
    void Update()
    {
		if(Input.GetKeyDown(_abilityHealButton))
		{
          DoAbility(healAbility);	 
		}
		if (Input.GetKeyDown(_abilityRageButton))
		{
			DoAbility(rageAbility);
		}
	 


	}

	  void DoAbility(IAbility ability)
	{
		 
		 StartCoroutine(ability.AbbilityTime());
	}
}
