using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour
{
	 private GameObject playerGO;
	[SerializeField] GameObject[] enemies;
 
	public HealthController healthController { get; private set; }
	public ManaController manaController { get; private set; }
	public CharacterMovementController characterMovement { get; private set; }
	public PlayerDeathController playerDeathController { get; private set; }
	public AnimatorController animatorController { get; private set; }
	public static StartScript GetStartScript { get; private set; }
	List<BaseController> allControllersList = new List<BaseController>();

	void Start()
    {
		playerGO = GameObject.FindGameObjectWithTag("Player");
		enemies = GameObject.FindGameObjectsWithTag("Enemy");

		GetStartScript = this;

		foreach(var enemy in enemies)
		{
			var health = new HealthController(enemy.GetComponent<HealthModel>());
			var enemyMovement = new CharacterMovementController(enemy.GetComponent<CharacterMovementModel>(), enemy);
			var enemyAnimatorController = new AnimatorController(enemy.GetComponent<AnimatorModel>(), enemy);
			allControllersList.Add(health);
			allControllersList.Add(enemyMovement);
			allControllersList.Add(enemyAnimatorController);
		}

		healthController = new HealthController(playerGO.GetComponent<HealthModel>());
		manaController = new ManaController(playerGO.GetComponent<ManaModel>());
		characterMovement = new CharacterMovementController(playerGO.GetComponent<CharacterMovementModel>(), playerGO);
		playerDeathController = new PlayerDeathController(playerGO.GetComponent<PlayerDeathModel>(),playerGO.GetComponent<PlayerDeathView>());
		animatorController = new AnimatorController(playerGO.GetComponent<AnimatorModel>(), playerGO);
		allControllersList.Add(manaController);
		allControllersList.Add(healthController);
		allControllersList.Add(characterMovement);
		allControllersList.Add(playerDeathController);
		allControllersList.Add(animatorController);
	}


    void Update()
    {
        foreach(var controller in allControllersList)
		{
			controller.ControllerUpdate();
		}
    }
}
