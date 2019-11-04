using Services;
using UnityEngine;
using Zenject;

public class UIController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] GameObject Player;
    private ISaveService _saveService;
	Health health;
	private void Awake()
	{
		health = Player.GetComponent<Health>();
	}

	[Inject]
    public void Init(ISaveService saveService)
    {
        print(_saveService + " injected correctly");
        _saveService = saveService;
    }

    public void SaveCharacterPosition()
    {
        _saveService.SaveCharacter(_player.position,health.health);
    }

    public void LoadCharacterPosition()
    {
        _player.position = _saveService.LoadCharacterPosition();
		health.Init(_saveService.LoadCharacterHealth());

    }

}
