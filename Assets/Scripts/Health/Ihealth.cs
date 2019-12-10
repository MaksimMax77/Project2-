using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Ihealth 
{
	void AddHealth(int healthToAdd);
	bool death { get; set; }
}
