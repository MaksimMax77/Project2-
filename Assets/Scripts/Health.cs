using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	[SerializeField] public int health;
	[SerializeField] int Maxhealth;
	public bool death;
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
			death = true;
		}
    }
	public void GetDamage(int damage)
	{	 
		health = health - damage;
	}	 
}
