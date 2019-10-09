using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseTransition  : NewTransition
{
	[SerializeField] public Transform _target;
	[SerializeField] public float DistanceCanSee;
	[SerializeField] public float time;
	// Update is called once per frame

	void OnEnable()
	{
		NeedTransit = false;
	}
	void Update()
    {
		 NeedTransit = false;
		var heading = transform.position - _target.position;

		if (heading.sqrMagnitude > DistanceCanSee * DistanceCanSee)
		{
			NeedTransit = true;
		}
	}
}
 
