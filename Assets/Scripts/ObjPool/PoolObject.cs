using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjPool
{
	[AddComponentMenu("Pool/PoolObject")]
	public class PoolObject : MonoBehaviour
	{


		#region Interface
		public void ReturnToPool()
		{
			gameObject.SetActive(false);
		}
		#endregion

		public void ReturnToPool(float seconds)
		{
			StartCoroutine(SecondsReturnToPool(seconds));
		}

		IEnumerator SecondsReturnToPool(float seconds)
		{
			yield return new WaitForSeconds(seconds);
			gameObject.SetActive(false);
		}
	}
}
