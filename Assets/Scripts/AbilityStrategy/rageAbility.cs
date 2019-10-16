using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rageAbility : MonoBehaviour,IAbility
{
	GameObject _effectAbility;
	int _needMana;
	float _timer;
	public bool _abilityUse = false;

	Mana _mana;
	public rageAbility(GameObject effectAbility, int needMana,  Mana mana, float timer)
	{
		_effectAbility = effectAbility;
		_needMana = needMana;
		_mana = mana;
		_timer = timer;
	}
	public rageAbility()
	{

	}

	public IEnumerator AbbilityTime()
	{
		if (_mana.mana >= _needMana && _abilityUse == false)
		{
			_abilityUse = true;
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
