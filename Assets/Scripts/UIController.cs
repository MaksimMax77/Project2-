using Services;
using UnityEngine;
using Zenject;

public class UIController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private ISaveService _saveService;

    [Inject]
    public void Init(ISaveService saveService)
    {
        print(_saveService + " injected correctly");
        _saveService = saveService;
    }

    public void SaveCharacterPosition()
    {
        _saveService.SaveCharacterPosition(_player.position);
    }

    public void LoadCharacterPosition()
    {
        _player.position = _saveService.LoadCharacterPosition();
    }

}
