using UnityEngine;

namespace Abilities
{
	public class UseAbility : MonoBehaviour
	{

		[SerializeField]private AbstractAbility healAbility2;
		[SerializeField]private AbstractAbility impulsAbility2;
		private ButtonManager buttonManager;

	    private void Awake()
		{
			buttonManager = GetComponent<ButtonManager>();
		}

		private void Update()
		{
			
			if (Input.GetKeyDown(buttonManager.useAbilityButton))
			{ 
				healAbility2.UseAbility();
			
			}

			if (Input.GetKeyDown(buttonManager.useAbilityButton3))
			{
				impulsAbility2.UseAbility();
			}
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.cyan;
			Gizmos.DrawLine(transform.position, Vector2.left * transform.localScale.x * 10);
		}
	}
}
