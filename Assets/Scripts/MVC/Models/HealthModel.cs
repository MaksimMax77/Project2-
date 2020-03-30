using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthModel : MonoBehaviour, Ihealth
{
	public int health;
	public int maxHealth = 100;
	[field : SerializeField] public bool death { get; set; }
	public bool Hit;
	public DamageType ResistanceType;

	public void GetDamage(int damage, DamageType damageType)
	{

		if (ResistanceType == damageType)
		{
			damage = damage / 2;
		}
		else if ( ResistanceType == DamageType.None || ResistanceType != damageType)
		{
			damage = damage;
		}

		StartCoroutine(Hitenumerator());//
		health -= damage;
	}

	public void AddHeal(int addHeal)
	{
		health += addHeal;
	}

	IEnumerator Hitenumerator() // это для анимаций 
	{
		 Hit = true;
		yield return new WaitForSeconds(0.6f);
		 Hit = false;
	}

	public void Init(int health)
	{
		this.health = health;
	}

}
