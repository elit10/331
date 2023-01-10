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
				//satýn alýnabildiyse
				print("alýndý");

				Notification.instance.ShowNotification("Evolved!", 2);

			}
			if (chosenEvo.Buy() == 1)
			{
				//zaten satýn alýnmýþ
				print("zaten alýnmmýþ");

				Notification.instance.ShowNotification("Already bought", 2);

			}
			if (chosenEvo.Buy() == 2)
			{
				//para yok
				print("kaynak yok");

				Notification.instance.ShowNotification("Not enough resources", 2);

			}
			if (chosenEvo.Buy() == 3)
			{
				//önceki evrim tamamlanmamýþ
				print("önceki evrimi yap");

				Notification.instance.ShowNotification("You need to do the previous evolution first!", 2);

			}
			if (chosenEvo.Buy() == 4)
			{
				//bu yok kilitli
				print("bu evrim kilitli");

				Notification.instance.ShowNotification("This evolution is locked", 2);

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
