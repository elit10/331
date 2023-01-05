using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public abstract class Organism : Nutrients
{
	public Nutrients nutrients;
	public Vector3 scale
	{
		get 
		{
			return transform.localScale;
		}
		set 
		{
			transform.DOScale(value, Time.deltaTime);
		}
	}

}
