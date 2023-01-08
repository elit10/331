using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvolutionPanel : Panel
{
    public GameObject evolutionsParent;
    public Evolution[] evolutions;

	public Text details;






	private void Start()
	{
		evolutions = GetComponentsInChildren<Evolution>();
	}

	public void BuyEvolution(string ID)
	{
		if (findEvolution(ID) != null)
		{
			if (findEvolution(ID).Buy(CustomCharacterController.instance.playerNutrients) == 0)
			{
				//satýn alýnabildiyse

			}
			if (findEvolution(ID).Buy(CustomCharacterController.instance.playerNutrients) == 1)
			{
				//zaten satýn alýnmýþ

			}
			if (findEvolution(ID).Buy(CustomCharacterController.instance.playerNutrients) == 2)
			{
				//para yok

			}

		}
	}

	public void ShowDetails(string text)
	{
		details.text = text;
	}

	public Evolution findEvolution(string ID)
	{
		foreach (Evolution evo in evolutions)
		{
			if (evo.ID == ID) { return evo; }
			
		}
		return null; 
	}


}
