using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHeeling : MonoBehaviour
{
	[SerializeField] private KeyCode _abilityDefButton = KeyCode.Q;
	[SerializeField] GameObject _effectAbility;
	[SerializeField] int _needMana;
	[SerializeField] bool _abilityUse=false;

 	Health _playerhealth;
	public float timer = 10;
	Mana mana;

	void Awake()
    {
		_effectAbility.SetActive(false);
		_playerhealth =  GetComponent<Health>();
		mana = GetComponent<Mana>();
	}

    void Update()
    {
		if (Input.GetKeyDown(_abilityDefButton))
		{
			if (mana.mana >= _needMana && _abilityUse==false)
			{
				StartCoroutine(AbbilityTime());
			}
			else if (_abilityUse == true)
			{
				Debug.Log("Скилл уже используется");
			}
			else if(mana.mana < _needMana)
			{
				Debug.Log("нехватает маны, петушара");
			}
		}
	}
	IEnumerator AbbilityTime()
	{
		_abilityUse = true;
		_playerhealth.AddHealth(25);
		_effectAbility.SetActive(true);
		mana.TakeMana(_needMana);
		yield return new WaitForSeconds(timer);
		_abilityUse = false;
		_effectAbility.SetActive(false);
		 
	}
}
