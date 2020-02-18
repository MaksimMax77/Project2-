using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GunSystem
{

	public class DrawGizmo : MonoBehaviour
	{
		[SerializeField] private GameObject player;

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.white;
		
				if (transform.position.x < player.transform.position.x)
				{
					Gizmos.DrawLine(transform.position,
						transform.position + -transform.right * transform.localScale.x * 12);
				}

				if (transform.position.x > player.transform.position.x)
				{
					Gizmos.DrawLine(transform.position,
						transform.position + transform.right * transform.localScale.x * 12);
				}
		}

	}
}
