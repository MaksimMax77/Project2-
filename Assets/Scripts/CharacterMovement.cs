using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterMovement : MonoBehaviour
{
    public Vector2 vecocity;
    public float speed = 0.0F;

    void Update()
    {
        transform.position += (Vector3) vecocity.normalized * Time.deltaTime * speed;
    }
}
