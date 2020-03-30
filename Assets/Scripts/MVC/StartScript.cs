using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StartScript : MonoBehaviour
{
	 
	 private GameObject playerGO;

	[SerializeField] public List<GameObject> enemies;

	public HealthController healthController { get; private set; }
	public ManaController manaController { get; private set; }
	public CharacterMovementController characterMovement { get; private set; }
	public PlayerDeathController playerDeathController { get; private set; }
	public AnimatorController animatorController { get; private set; }
	public UseAbilityController abilityController { get; private set; }

	public static StartScript GetStartScript { get; private set; }

	List<BaseController> allControllersList = new List<BaseController>();

	void Start()
    {
		 
		playerGO = GameObject.FindGameObjectWithTag("Player");

	    GetStartScript = this;

		FindEnemies();
 
		healthController = new HealthController(playerGO.GetComponent<HealthModel>());
		manaController = new ManaController(playerGO.GetComponent<ManaModel>());
		characterMovement = new CharacterMovementController(playerGO.GetComponent<CharacterMovementModel>(), playerGO);
		playerDeathController = new PlayerDeathController(playerGO.GetComponent<PlayerDeathModel>(),playerGO.GetComponent<PlayerDeathView>());
		animatorController = new AnimatorController(playerGO.GetComponent<AnimatorModel>(), playerGO);
		abilityController = new UseAbilityController(playerGO.GetComponent<ButtonManager>(),
			playerGO.GetComponent<UseAbilityModel>(), playerGO);
		allControllersList.Add(manaController);
		allControllersList.Add(healthController);
		allControllersList.Add(characterMovement);
		allControllersList.Add(playerDeathController);
		allControllersList.Add(animatorController);
		allControllersList.Add(abilityController);
	}


	void InitCharactersWithTag(List<GameObject> characters)
	{
		foreach (var character  in characters)
		{
			var health = new HealthController(character.GetComponent<HealthModel>());
			var enemyMovement = new CharacterMovementController(character.GetComponent<CharacterMovementModel>(), character);
			var enemyAnimatorController = new AnimatorController(character.GetComponent<AnimatorModel>(), character);
			allControllersList.Add(health);
			allControllersList.Add(enemyMovement);
			allControllersList.Add(enemyAnimatorController);
		}
	}

	public void AddSpawnedEnemyInList(GameObject character) 
	{
		enemies.Add(character);
		var health = new HealthController(character.GetComponent<HealthModel>());
		var enemyMovement = new CharacterMovementController(character.GetComponent<CharacterMovementModel>(), character);
		var enemyAnimatorController = new AnimatorController(character.GetComponent<AnimatorModel>(), character);
		allControllersList.Add(health);
		allControllersList.Add(enemyMovement);
		allControllersList.Add(enemyAnimatorController);
	}//этот метод для класса AlradySpawnCharacter для врагов,
	 //которые появляются входе выполнения програмы

	public void FindEnemies()
	{
		var enemiesMassiv = GameObject.FindGameObjectsWithTag("Enemy");
		foreach (var enemy in enemiesMassiv)
		{
			enemies.Add(enemy);
		}

	    var enemiesHealers = GameObject.FindGameObjectsWithTag("EnemyHealer");
		 
		foreach (var enemy in enemiesHealers)
		{
			enemies.Add(enemy);
		}
		InitCharactersWithTag(enemies);
	}

	void Update()
    {
        foreach(var controller in allControllersList)
		{
			controller.ControllerUpdate();
		}
    }
}
