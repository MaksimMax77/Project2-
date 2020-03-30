using EnemySystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : AbstractEnemy
{
	[SerializeField] GameObject bullet;
	[SerializeField] Transform gunPoint;
	[SerializeField] GameObject Gun;
	[SerializeField] private float dodgeTimer;

	[SerializeField] private bool enemyIsWizard;
	private CharBehavior charBehavior;


	public AbstractBullet currentBullet;

	public override void EnemyAttack()
	{
		throw new System.NotImplementedException();
	}

	public override void EnemyDeath()
	{
		throw new System.NotImplementedException();
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
