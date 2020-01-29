using Services;
using UnityEngine;
using Zenject;
using UnityEngine.SceneManagement;


namespace UiSystem
{
	public class UIController : MonoBehaviour
	{

		[SerializeField] GameObject player;

		private ISaveService saveService;
		Health health;


		private void Awake()
		{
			health = player.GetComponent<Health>();
		}

		[Inject]
		public void Init(ISaveService saveService)
		{
			print(saveService + " injected correctly");
			this.saveService = saveService;
		}

		public void SaveCharacterPosition()
		{
			saveService.SaveCharacter(player.transform.position, health.HealthProp);
		}

		public void LoadCharacterPosition()
		{
			player.transform.position = saveService.LoadCharacterPosition();
			health.Init(saveService.LoadCharacterHealth());
		}
	}
}
