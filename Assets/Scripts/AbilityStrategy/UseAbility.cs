using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseAbility : MonoBehaviour
{
	 
	[SerializeField] GameObject healAbbilityEffect;
	[SerializeField] GameObject rageAbbilityEffect;
	[SerializeField] GameObject impulsAbbilityEffect;
	[SerializeField] int impulsDamage;

	[SerializeField] GameObject enemy;
	[SerializeField]int neadMana;
	[SerializeField] float timer;
	[SerializeField] DamageType impulsDamageType;
	[SerializeField] GameObject player;
	RaycastHit2D hit; 

	Health health;
	Mana mana;
    ButtonManager buttonManager;
	HealAbility healAbility;
	RageAbility rageAbility;
	ImpulsAbility impulsAbility;
	public DamageType damageType;


	void Start()
    {
		buttonManager = GetComponent<ButtonManager>();
		   health = GetComponent<Health>();
		mana = GetComponent<Mana>();
		healAbility = new HealAbility(healAbbilityEffect, neadMana, health, mana,timer );
		rageAbility = new RageAbility(rageAbbilityEffect, neadMana, mana, timer);
		impulsAbility = new ImpulsAbility(impulsAbbilityEffect, neadMana, mana, timer, impulsDamage, impulsDamageType, hit, player);
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
			//Physics2D.queriesStartInColliders = false;
			//	hit = Physics2D.Raycast(transform.position, Vector2.left * transform.localScale.x, 25);
			 DoAbility(impulsAbility);
			//StartCoroutine(AbbilityTime());
		}
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

	public IEnumerator AbbilityTime()
	{
		if ( mana.mana >= neadMana  )
		{
			 
			Physics2D.queriesStartInColliders = false;
			 hit = Physics2D.Raycast( transform.position, Vector2.left *  transform.localScale.x, 10);
			if ( hit.collider != null &&  hit.collider.tag == "Enemy")
			{
				var Enemy1 = hit.collider.gameObject;

				var _enemyHealth =  Enemy1.GetComponent<Health>();

				_enemyHealth.GetDamage(10, damageType);
				if ( transform.position.x < Enemy1.transform.position.x)
				{
					Enemy1.transform.position += Vector3.right * 10;
				}
				else if ( transform.position.x > Enemy1.transform.position.x)
				{
					Enemy1.transform.position += Vector3.left * 10;
				}
			}
			impulsAbbilityEffect.SetActive(true);
			mana.TakeMana(neadMana);
			yield return new WaitForSeconds(timer);
			//_abilityUse = false;
			impulsAbbilityEffect.SetActive(false);
		}
		//if (_abilityUse == true)
		//{
		//
		//	Debug.Log("Скилл уже используется");
		//}
		else if (mana.mana < neadMana)
		{
			Debug.Log("нехватает маны, петушара");
		}
	}
}
