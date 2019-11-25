using Services;
using UnityEngine;
using Zenject;

public class UIController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
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
		saveService.SaveCharacter(playerTransform.position,health.health);
    }

    public void LoadCharacterPosition()
    {
		playerTransform.position = saveService.LoadCharacterPosition();
		health.Init(saveService.LoadCharacterHealth());
    }
}
