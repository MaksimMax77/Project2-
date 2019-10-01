using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.UI;
public class GiveMeXP : MonoBehaviour
{
	 Health health;
    [SerializeField] GameObject enemy ;
	[SerializeField] int XpForEnemy;
	[SerializeField] Slider sliderXp;

	private IPlayerXP _playerXP;
	 
	private void Awake()
	{
	 
		health = enemy.GetComponent<Health>();
	}
	private void Update()
	{
		sliderXp.value = _playerXP._xp;

		if (health.health <= 1)
		{
		 
			 _playerXP.GetXP(XpForEnemy);
		} 
	}

	[Inject]
	private void Init(IPlayerXP playerXP)
	{
		Debug.Log("it,s waork");
		_playerXP = playerXP;
	}
 
}
