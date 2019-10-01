using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
public class PlayerXP : IPlayerXP // опыт игрока
{
	public int _xp { get; set; }
	 
	public void GetXP(int xp)
	{
		Debug.Log("GetXpMetod");
		_xp = _xp + xp;
	}
}
