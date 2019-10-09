using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolTransition : NewTransition 
{
	[SerializeField] public Transform _target;
	[SerializeField] public float DistanceCanSee;
	[SerializeField] public float time;

	void OnEnable()
	{
	 NeedTransit = false;
	}

	private void Update()
	{
		
		var heading = transform.position - _target.position;

		if (heading.sqrMagnitude < DistanceCanSee * DistanceCanSee)
		{
			NeedTransit = true;
		}
		 
	 
	}

	IEnumerator Timer()
	{
		yield return new WaitForSeconds(time);
		NeedTransit = true;
	}
}
