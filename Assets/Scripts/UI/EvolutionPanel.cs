using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvolutionPanel : Panel
{
    public GameObject evolutionsParent;
    public Evolution[] evolutions;

	public Text details;
	public Image detailImage;

	public Evolution chosenEvo;



	private void Start()
	{
		evolutions = GetComponentsInChildren<Evolution>();
	}

	public void BuyEvolution()
	{;

		if (chosenEvo != null)
		{
			if (chosenEvo.Buy() == 0)
			{
				//sat�n al�nabildiyse
				print("al�nd�");

			}
			if (chosenEvo.Buy() == 1)
			{
				//zaten sat�n al�nm��
				print("zaten al�nmm��");

			}
			if (chosenEvo.Buy() == 2)
			{
				//para yok
				print("kaynak yok");

			}
			if (chosenEvo.Buy() == 3)
			{
				//�nceki evrim tamamlanmam��
				print("�nceki evrimi yap");

			}
			if (chosenEvo.Buy() == 4)
			{
				//bu yok kilitli
				print("bu evrim kilitli");

			}

		}
	}

	public void ShowDetails(string text, Sprite sp , Evolution source)
	{
		details.text = text;
		detailImage.sprite = sp;
		chosenEvo = source;
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
