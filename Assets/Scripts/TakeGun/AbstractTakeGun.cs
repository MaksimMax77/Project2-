using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractTakeGun : MonoBehaviour
{
	public float _distance = 5f;
	public float _throwObj = 0.5f;
	public Transform holdPoint;
	public abstract void TakeGun();
	
 
}
