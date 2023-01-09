using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : Evolution
{
	public override void Effect()
	{
		PPManager.instance.eyes = true;
	}
}
