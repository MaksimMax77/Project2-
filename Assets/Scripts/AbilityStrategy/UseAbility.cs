using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseAbility : MonoBehaviour
{
	 
	[SerializeField] GameObject HealAbbilityEffect;
	[SerializeField] GameObject RageAbbilityEffect;
	[SerializeField] GameObject ImpulsAbbilityEffect;
	[SerializeField] int impulsDamage;

	[SerializeField] GameObject enemy;
	[SerializeField]int NeadMana;
	[SerializeField] float timer;
	[SerializeField] DamageType impulsdamageType;
	[SerializeField] GameObject Player;
	RaycastHit2D hit; 

	Health health;
	Mana _mana;
    ButtonManager buttonManager;
	healAbility healAbility;
	rageAbility rageAbility;
	ImpulsAbility impulsAbility;

	public DamageType damageType;
	void Start()
    {
		buttonManager = GetComponent<ButtonManager>();
		   health = GetComponent<Health>();
		_mana = GetComponent<Mana>();
		healAbility = new healAbility(HealAbbilityEffect, NeadMana, health, _mana,timer );
		rageAbility = new rageAbility(RageAbbilityEffect, NeadMana, _mana, timer);
		impulsAbility = new ImpulsAbility(ImpulsAbbilityEffect, NeadMana, _mana, timer, impulsDamage, impulsdamageType, hit, Player);


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
		if (Input.GetKeyDown(buttonManager.UseAbilityButton3))
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
		if (_mana.mana >= NeadMana  )
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
			ImpulsAbbilityEffect.SetActive(true);
			_mana.TakeMana(NeadMana);
			yield return new WaitForSeconds(timer);
			//_abilityUse = false;
			ImpulsAbbilityEffect.SetActive(false);
		}
		//if (_abilityUse == true)
		//{
		//
		//	Debug.Log("Скилл уже используется");
		//}
		else if (_mana.mana < NeadMana)
		{
			Debug.Log("нехватает маны, петушара");
		}
	}
}
