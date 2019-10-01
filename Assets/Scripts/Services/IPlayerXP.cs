using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerXP
{
	void GetXP(int xp);
	int _xp { get; set; }
}
