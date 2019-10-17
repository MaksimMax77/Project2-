using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeWeapon : MonoBehaviour
{
	[SerializeField] List<GameObject> GameObjects;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "CanTake")
		{
			var obj = collision.gameObject;
			GameObjects.Add(obj);
			obj.SetActive(false);
		}
	}
}
