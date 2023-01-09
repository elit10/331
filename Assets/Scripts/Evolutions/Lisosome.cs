using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lisosome : Evolution
{
	public override void Effect()
	{
		CustomCharacterController.instance.nutrientMultiplier = 2;
	}
}
