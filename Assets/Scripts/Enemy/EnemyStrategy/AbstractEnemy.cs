using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEnemy : MonoBehaviour
{
	Health health;
	CharacterMovement characterMovement;
	[SerializeField] Transform[] patrolSpots;
	int randomSpot;
	[SerializeField] int enemyDamage;
	[SerializeField] DamageType damageType;
	[SerializeField] float timer;
	[SerializeField] float patrolTimer;
	GameObject player;
	[SerializeField] float distaceToPla;
	Collider2D _collider;
	// Update is called once per frame
	void Update()
    {
        
    }
}
