using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UseAbility : MonoBehaviour
{
	public Ihealth health;
	public IMana mana;
    ButtonManager buttonManager;
 
	[SerializeField] HealAbility2 healAbility2;
	[SerializeField] ImpulsAbility2 impulsAbility2;


	void Awake()
    {
		buttonManager = GetComponent<ButtonManager>();
	}

    // Update is called once per frame
    void Update()
    {
		if(Input.GetKeyDown(buttonManager.useAbilityButton))
		{
		  
			healAbility2.UseAbility();
		}
	 
		if (Input.GetKeyDown(buttonManager.useAbilityButton3))
		{
	 
			impulsAbility2.UseAbility();
		}
	}
 

 
}
