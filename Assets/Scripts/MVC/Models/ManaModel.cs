using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaModel : MonoBehaviour , IMana
{
	[field: SerializeField] public float mana { get; set; }
	public int maxMana=100;
}
