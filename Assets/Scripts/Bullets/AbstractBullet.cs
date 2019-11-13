using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractBullet : MonoBehaviour
{
    public float speed;
	[SerializeField] protected int damage;
	[SerializeField] protected DamageType damageType;
	 
}
