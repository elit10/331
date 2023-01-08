using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ribosome : Evolution
{
	public override void Effect()
	{
		InvokeRepeating("Heal", 0, 1);
	}

	private void Heal()
	{
		CustomCharacterController.instance.health++;
	}

}
