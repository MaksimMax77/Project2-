using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
	[field: SerializeField] public float mana { get; private set; }
	[field: SerializeField] public int maxMana { get; private set; } = 100;

    void Update()
    {
		ManaRegen();
    }

	public void TakeMana(int ManaPrice)
	{
		mana -= ManaPrice;
	}
	void ManaRegen()
	{
		if (mana < maxMana)
		{
			mana += 1 * Time.deltaTime;
		}
	}
}
