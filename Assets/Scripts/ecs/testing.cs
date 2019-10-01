﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Collections;
using Unity.Rendering;
using Unity.Mathematics;

public class testing : MonoBehaviour
{ 
	[SerializeField] Mesh Mesh;
	[SerializeField] Material material;


    void Start()
    {
		EntityManager entityManager = World.Active.EntityManager;
		EntityArchetype entityArchetype = entityManager.CreateArchetype(typeof(LevelComponent), 
			typeof(Translation),
			typeof(RenderMesh),
			typeof(LocalToWorld),
			typeof(MoveSpeedComponent));
		NativeArray<Entity> entityArray = new NativeArray<Entity>(1, Allocator.Temp);
		entityManager.CreateEntity(entityArchetype, entityArray);
		for (int i = 0; i < entityArray.Length; i++)
		{
			Entity entity = entityArray[i];
            entityManager.SetComponentData(entity, new LevelComponent { level = UnityEngine.Random.Range(10f, 20f) });

			entityManager.SetSharedComponentData(entity, new RenderMesh { mesh = Mesh, material = material });

			entityManager.SetComponentData(entity, new MoveSpeedComponent { speed = UnityEngine.Random.Range(1f, 10f) });

			entityManager.SetComponentData(entity, new Translation
			{
				Value = new float3(UnityEngine.Random.Range(-8, 8f),UnityEngine.Random.Range(-5, 5f), 0)
			});
		}
		
	    
		entityArray.Dispose();

	}
 
}
