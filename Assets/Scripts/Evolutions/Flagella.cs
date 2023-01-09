using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flagella : Evolution
{
	public override void Effect()
	{
		CustomCharacterController.instance.flagella = true;
	}
}
