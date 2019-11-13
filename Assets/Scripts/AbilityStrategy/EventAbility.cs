using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventAbility
{
	public delegate void MethodContainer();
	public event MethodContainer myEvent;
	healAbility _healAbility = new healAbility();

	void  Start()
	{
		myEvent += _healAbility.GetMessege;
	}
}
