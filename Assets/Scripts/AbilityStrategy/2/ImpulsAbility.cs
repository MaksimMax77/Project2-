using UnityEngine;

namespace Abilities
{
	public class ImpulsAbility : AbstractAbility 
	{
		public int damage;
		public DamageType damageType;
		private RaycastHit2D hit;


		
		void PushEnemy()
		{
			damageType = DamageType.Standart;
			var enemy = hit.collider.gameObject;
			var _enemyHealth = enemy.GetComponent<HealthModel>();
			_enemyHealth.GetDamage(damage, damageType);
			if (transform.position.x < enemy.transform.position.x)
			{
				enemy.transform.position += Vector3.right * 10;
			}
			else if (transform.position.x > enemy.transform.position.x)
			{
				enemy.transform.position += Vector3.left * 10;
			}
		}

		public override void UseAbility()
		{
			if (manaModel.mana >= neadMana && abilityUse == false)
			{
				abilityUse = true;
				hit = Physics2D.Raycast(  transform.position, Vector2.left * transform.localScale.x, 10);
				if (hit.collider != null)
				{
					PushEnemy();
				}
				manaModel.mana -= neadMana;
			}
		}

		private void Update()
		{
			AbilityTimer();
		}
	}
}
