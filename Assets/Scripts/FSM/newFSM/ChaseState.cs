using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : NewState 
{
	[SerializeField] Transform target;
	CharacterMovement _characterMovement;


    void Awake()
    {
		_characterMovement = GetComponent<CharacterMovement>();

	}

    // Update is called once per frame
    void Update()
    {
		_characterMovement.vecocity = target.position - transform.position;
	}
}
