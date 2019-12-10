using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMana  
{
    void TakeMana(int ManaPrice);
	void ManaRegen();
   float mana { get;  set; }
}
