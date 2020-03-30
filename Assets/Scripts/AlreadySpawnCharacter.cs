using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlreadySpawnCharacter : MonoBehaviour
{
	StartScript start;

    void Start()
    {
		var starScript = GameObject.FindGameObjectWithTag("StartScript");
		start = starScript.GetComponent<StartScript>();
		start.AddSpawnedEnemyInList(gameObject);
	}
}
