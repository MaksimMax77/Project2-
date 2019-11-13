using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpulsAbility : MonoBehaviour,IAbility
{
	GameObject _effectAbility;
	GameObject _enemy;
	Health _enemyHealth;
	int _damage;
	DamageType _damageType;
	int _needMana;
	float _timer;
	bool _abilityUse = false;
	GameObject _player;
	 
	Mana _mana;
	RaycastHit2D _hit;

	public ImpulsAbility(GameObject effectAbility, int needMana,   Mana mana, float timer, 
	int damage, DamageType  damageType, RaycastHit2D hit,GameObject player)
	{
		 
		_effectAbility = effectAbility;
		_damage = damage;
		_damageType = damageType;
		_timer = timer;
		_needMana = needMana;
		_mana = mana;
		_hit = hit;
		_player = player;
	}

	public IEnumerator AbbilityTime()
	{
		if (_mana.mana >= _needMana && _abilityUse == false)
		{
			_abilityUse = true;
		 	Physics2D.queriesStartInColliders = false;
	 	_hit = Physics2D.Raycast(_player.transform.position, Vector2.left * _player.transform.localScale.x, 10);
			if (_hit.collider != null && _hit.collider.tag == "Enemy")
			{
				var Enemy1 = _hit.collider.gameObject;
				var _enemyHealth = Enemy1.GetComponent<Health>();
				_enemyHealth.GetDamage(10, _damageType);
				 if (_player.transform.position.x < Enemy1.transform.position.x)
			 	{
			 		Enemy1.transform.position += Vector3.right * 10;
			 	}
			  	else if (_player.transform.position.x > Enemy1.transform.position.x)
			 	{
				 	Enemy1.transform.position += Vector3.left * 10;
			    }
		 	}
			_effectAbility.SetActive(true);
			_mana.TakeMana(_needMana);
			yield return new WaitForSeconds(_timer);
			_abilityUse = false;
			_effectAbility.SetActive(false);
		}
		if (_abilityUse == true)
		{

			Debug.Log("Скилл уже используется");
		}
		else if (_mana.mana < _needMana)
		{
			Debug.Log("нехватает маны, петушара");
		}
	}

	 
}
