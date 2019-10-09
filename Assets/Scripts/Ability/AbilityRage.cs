using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityRage : MonoBehaviour
{
	[SerializeField] KeyCode _abilityDefButton = KeyCode.R;
	[SerializeField] GameObject _effectAbility;
	[SerializeField] int _needMana;
	[SerializeField] bool _abilityUse;
	[SerializeField] float timer;
	PlayerController _playerController;
	 
	Mana _mana;
	  
	void Awake()
    {
	    _effectAbility.SetActive(false);
	    _abilityUse = false;
		_mana = GetComponent<Mana>();
		_playerController = GetComponent<PlayerController>();
	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(_abilityDefButton))
		{
			if (_mana.mana >= _needMana && _abilityUse == false)
			{
				StartCoroutine(AbbilityTime());
			}
			else if (_abilityUse == true)
			{
				Debug.Log("Скилл уже используется");
			}
			else if (_mana.mana < _needMana)
			{
				Debug.Log("нехватает маны, петушара");
			}
		}
	}
	IEnumerator AbbilityTime()
	{
		_abilityUse = true;
		_playerController.PlayerDamage = _playerController.PlayerDamage* 2;
		_effectAbility.SetActive(true);
		_mana.TakeMana(_needMana);
		yield return new WaitForSeconds(timer);
		_abilityUse = false;
		_effectAbility.SetActive(false);
		_playerController.PlayerDamage = 15;
	}
}
