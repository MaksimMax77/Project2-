using GunSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawnerBullet : AbstractBullet
{
	[SerializeField] private GameObject character;
	private Aim aim;

	private void Start()
	{
		var enemyGun = GameObject.FindGameObjectWithTag("PlayerGun");
		aim = enemyGun.GetComponent<Aim>();
	}

	public override void SpawnCharacter()
	{
		StartCoroutine(SpawnCharacterEnumerator());
	}

	IEnumerator SpawnCharacterEnumerator()
	{
		yield return new WaitForSeconds(2);
		Instantiate(character,transform.position,Quaternion.identity);
		Explosion();
		Destroy(gameObject);
		
	}
}
