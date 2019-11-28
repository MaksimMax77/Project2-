using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UseAbility : MonoBehaviour
{
	 
	[SerializeField] GameObject healAbbilityEffect;
	[SerializeField] GameObject rageAbbilityEffect;
	[SerializeField] GameObject impulsAbbilityEffect;
	[SerializeField] int impulsDamage;

 
	[SerializeField]int neadMana;
	[SerializeField] float timer;
	[SerializeField] DamageType impulsDamageType;
	[SerializeField] GameObject player;
	RaycastHit2D hit; 

	Ihealth health;
	Mana mana;
    ButtonManager buttonManager;
	HealAbility healAbility;
	RageAbility rageAbility;
	ImpulsAbility impulsAbility;
	public DamageType damageType;


	void Awake()
    {
		buttonManager = GetComponent<ButtonManager>();
		//mana = GetComponent<Mana>();

		healAbility.HealAbilityInit(healAbbilityEffect,  neadMana, health, mana, timer);//
		impulsAbility.ImpulsAbilityInit(impulsAbbilityEffect, neadMana, mana, timer, impulsDamage, impulsDamageType, hit, player);//
		rageAbility.RageAbilityInit(rageAbbilityEffect, neadMana, mana, timer);//
	}

    // Update is called once per frame
    void Update()
    {
		if(Input.GetKeyDown(buttonManager.useAbilityButton))
		{
          DoAbility(healAbility);	 
		}
		if (Input.GetKeyDown(buttonManager.useAbilityButton2))
		{
			DoAbility(rageAbility);
		}
		if (Input.GetKeyDown(buttonManager.useAbilityButton3))
		{
			 DoAbility(impulsAbility);
		}
	}

	[Inject]
	public void ZenjectInit(ImpulsAbility impulsAbility , HealAbility healAbility, RageAbility rageAbility,Ihealth  health)
	{
		this.impulsAbility = impulsAbility;
		this.healAbility = healAbility;
		this.rageAbility = rageAbility;
		this.health = health;
	}

	void DoAbility(IAbility ability)
	{ 
		 StartCoroutine(ability.AbbilityTime());
	}
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawLine(transform.position, transform.position + Vector3.left * transform.localScale.x * 10);
	}
}
