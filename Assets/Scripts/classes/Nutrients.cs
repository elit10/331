using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nutrients : MonoBehaviour
{
	public int carbs;
	public int protein;
	public int fat;

	private void Start()
	{
		InvokeRepeating("Loop", 0, 1f);
	}

	private void Loop()
	{
		if (Vector3.Distance(CustomCharacterController.instance.transform.position, transform.position) > GameManager.instance.despawnDistance)
		{
			NPCSpawner.instance.removeFromMap(gameObject);
		}
	}

	public static Nutrients Add(Nutrients a, Nutrients b)
	{
		Nutrients toReturn = new Nutrients();

		toReturn.carbs = a.carbs + b.carbs;
		toReturn.protein = a.protein + b.protein;
		toReturn.fat = a.fat + b.fat;

		return toReturn;
	}


	public override string ToString()
	{ 
		return carbs.ToString() + " " + protein.ToString() + " " + fat.ToString();
	
	}
}
