using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Panel : MonoBehaviour
{
	public void Activate()
	{
		gameObject.SetActive(!gameObject.activeSelf);
	}

	public void Activate(bool val)
	{
		gameObject.SetActive(val);
	}
}
