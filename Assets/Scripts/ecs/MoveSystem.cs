using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
public class MoveSystem :ComponentSystem
{
	protected override void OnUpdate()
	{
        Entities.ForEach((ref Translation translation,ref MoveSpeedComponent moveSpeedComponent ) => 
		{
			translation.Value.x += moveSpeedComponent.speed * Time.deltaTime;
			if (translation.Value.x > 15f)
			{
				moveSpeedComponent.speed = -Mathf.Abs(moveSpeedComponent.speed);
			}
			if (translation.Value.x < 15f)
			{
				moveSpeedComponent.speed = +Mathf.Abs(moveSpeedComponent.speed);
			}
		});
	}
}
