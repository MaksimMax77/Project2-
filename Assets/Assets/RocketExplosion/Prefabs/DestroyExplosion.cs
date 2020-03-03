using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExplosion : MonoBehaviour
{
	private void Update()
	{
		Destroy(gameObject, 1f);
	}
}
