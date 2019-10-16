using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class healAbility :MonoBehaviour, IAbility
{

	GameObject _effectAbility;
	int _needMana;
    float _timer ;
    bool _abilityUse = false;

	Health _playerhealth;
	Mana _mana ;
	 

	public healAbility(  GameObject effectAbility, int needMana,Health playerhealth, Mana mana, float timer)
	{
		_effectAbility = effectAbility;
		_needMana = needMana;
		_playerhealth = playerhealth;
		_mana = mana;
		_timer = timer;
	}
 
	public IEnumerator AbbilityTime()
	{
		if (_mana.mana >= _needMana && _abilityUse == false)
		{
			_abilityUse = true;
			_playerhealth.AddHealth(25);
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
