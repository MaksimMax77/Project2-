using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterMovement _characterMovement;

    void Awake()
    {
        _characterMovement = GetComponent<CharacterMovement>();
    }

    void Update()
    {
        _characterMovement.vecocity = new Vector2(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical"));
    }
}
