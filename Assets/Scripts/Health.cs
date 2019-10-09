﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	[field: SerializeField] public int health { get; set; } 
    [field: SerializeField] public int maxHealth { get; private set; } = 100;
    [field: SerializeField] public bool death { get; private set; }

    public void Init(int health)
    {
        this.health = health;
    }

    public void AddHealth(int healthToAdd)
    {
        health = Mathf.Min(health + healthToAdd, maxHealth);
    }
    
	public void GetDamage(int damage)
    {
		health -= damage;
       // health -= Mathf.Max( damage,health  );
        if (health <= 0)
		{
          death = true;
		}		
    }	  
}
