using UnityEngine;

namespace Abilities
{
	public class ImpulsAbility : AbstractAbility 
	{
		public int damage;
		public DamageType damageType;
		private RaycastHit2D hit;
		private ManaModel manaModel;
		private GameObject gameObject;

		public ImpulsAbility(GameObject gameObject, ManaModel manaModel)
		{
			this.manaModel = manaModel;
			this.gameObject = gameObject;
		}

		
		void PushEnemy()
		{
			damageType = DamageType.Standart;
			var enemy = hit.collider.gameObject;
			var _enemyHealth = enemy.GetComponent<HealthModel>();
			_enemyHealth.GetDamage(damage, damageType);
			if (gameObject.transform.position.x < enemy.transform.position.x)
			{
				enemy.transform.position += Vector3.right * 10;
			}
			else if (gameObject.transform.position.x > enemy.transform.position.x)
			{
				enemy.transform.position += Vector3.left * 10;
			}
		}

		public override void UseAbility()
		{
			if (manaModel.mana >= neadMana && abilityUse == false)
			{
				abilityUse = true;
				hit = Physics2D.Raycast(gameObject.transform.position, Vector2.left * gameObject.transform.localScale.x, 10);
				if (hit.collider != null)
				{
					PushEnemy();
				}
				manaModel.mana -= neadMana;
			}
		}

		public override void AbilityUpdate(GameObject abilityEffect)
		{
			AbilityTimer(abilityEffect);
		}
	}
}
