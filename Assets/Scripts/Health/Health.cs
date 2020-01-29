using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Health : MonoBehaviour,Ihealth
{
	[field: SerializeField] private int health { get; set; } 
    [field: SerializeField] private int maxHealth { get; set; } = 100;
    [field: SerializeField] public bool death { get; set; }
	[SerializeField]DamageType ResistanceType;

	public int HealthProp
	{
		get {return health;}
		set {health = value;}
	}


	public bool Hit;//для аниматора
	 

	public void Init(int health)
    {
        this.health = health;
    }

    public void AddHealth(int healthToAdd)
    {
        health = Mathf.Min(health + healthToAdd, maxHealth);
    }
    
	public void GetDamage(int damage, DamageType damageType )
    {
	 
		if ( ResistanceType == damageType  )
		{
			damage = damage / 2;	
		}
		else if(ResistanceType == DamageType.None|| ResistanceType != damageType)
		{
            damage = damage;
		}
		StartCoroutine(Hitenumerator());
	   health -= damage;
       // health -= Mathf.Max( damage,health  );
        if (health <= 0)
		{
          death = true;
		}		
    }
	IEnumerator Hitenumerator()
	{
		Hit = true;
		yield return new WaitForSeconds(0.6f);
		Hit = false;
	}
	
}
