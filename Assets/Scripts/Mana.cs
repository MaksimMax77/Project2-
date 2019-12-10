using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour,IMana
{
	[field: SerializeField] public float mana { get; set; }
	[field: SerializeField] public int maxMana { get; private set; } = 100;

    void Update()
    {
		ManaRegen();
    }

	public void TakeMana(int ManaPrice)
	{
		mana -= ManaPrice;
	}
	public void ManaRegen()
	{
		if (mana < maxMana)
		{
			mana += 1 * Time.deltaTime;
		}
	}

	 
}
