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
		HealthModel health;


		private void Awake()
		{
			health = player.GetComponent<HealthModel>();
		}

		[Inject]
		public void Init(ISaveService saveService)
		{
			print(saveService + " injected correctly");
			this.saveService = saveService;
		}

		public void SaveCharacterPosition()
		{
			saveService.SaveCharacter(player.transform.position, health.health);
		}

		public void LoadCharacterPosition()
		{
			player.transform.position = saveService.LoadCharacterPosition();
			health.Init(saveService.LoadCharacterHealth());
		}
	}
}
