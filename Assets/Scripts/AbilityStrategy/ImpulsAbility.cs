using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpulsAbility : MonoBehaviour,IAbility
{
	GameObject effectAbility;
	GameObject enemy;
	Health enemyHealth;
	int damage;
	DamageType damageType;
	int needMana;
	float timer;
	bool abilityUse = false;
	GameObject player;
	 
	Mana mana;
	RaycastHit2D hit;

	public ImpulsAbility(GameObject effectAbility, int needMana,   Mana mana, float timer, 
	int damage, DamageType  damageType, RaycastHit2D hit,GameObject player)
	{
		 
		this.effectAbility = effectAbility;
		this.damage = damage;
		this.damageType = damageType;
		this.timer = timer;
		this.needMana = needMana;
		this.mana = mana;
		this.hit = hit;
		this.player = player;
	}

	public IEnumerator AbbilityTime()
	{
		if (mana.mana >= needMana && abilityUse == false)
		{
			abilityUse = true;
		 	Physics2D.queriesStartInColliders = false;
	 	    hit = Physics2D.Raycast( player.transform.position, Vector2.left *  player.transform.localScale.x, 10);
			if ( hit.collider != null &&  hit.collider.tag == "Enemy")
			{
				var Enemy1 =  hit.collider.gameObject;
				var _enemyHealth = Enemy1.GetComponent<Health>();
				_enemyHealth.GetDamage(10,  damageType);
				 if (player.transform.position.x < Enemy1.transform.position.x)
			 	{
			 		Enemy1.transform.position += Vector3.right * 10;
			 	}
			  	else if (player.transform.position.x > Enemy1.transform.position.x)
			 	{
				 	Enemy1.transform.position += Vector3.left * 10;
			    }
		 	}
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
