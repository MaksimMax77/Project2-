using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	[SerializeField] int health;
	[SerializeField] int Maxhealth;
	 
	private void Awake()
	{
		Maxhealth = 100; 
	}


	void Update()
    {
		if (health > Maxhealth)
		{
			health = Maxhealth;
		}
		if (health <= 0)
		{
			health =   0;
		}
    }
	public void GetDamage(int damage)
	{
		 
		health = health - damage;
	}	 
}
