using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public abstract class Evolution : MonoBehaviour
{
    public string ID;
    private Nutrients value;

    public int carb;
    public int protein;
    public int fat;


    public bool isActive;

    public string details;
    public Sprite sp;
    public EvolutionPanel ep;

	public void Start()
	{
        ep = UIManager.instance.evolutionPanel;

        value = new Nutrients();

        value.carbs = carb;
        value.protein = protein;
        value.fat = fat;

		sp = transform.GetChild(1).GetComponent<Image>().sprite;

	}

	public bool isEnough(Nutrients val)
    {
        bool toReturn = true;

        if (val.carbs < value.carbs) { toReturn = false; }

        if (val.fat < value.fat) { toReturn = false; }

        if (val.protein < value.protein) { toReturn = false; }

        return toReturn;
    }

    public int Buy()
    {
        if (isActive) { return 1; }

        if (isEnough(CustomCharacterController.instance.playerNutrients))
        {
            CustomCharacterController.instance.playerNutrients =  Nutrients.Remove(CustomCharacterController.instance.playerNutrients, value);
            GetComponent<Image>().color = GameManager.instance.BoughtColor;
            isActive = true;
            Effect();
            return 0;
        }
    
        return 2;
    }

    public void ShowDetails()
    {
        ep.ShowDetails(details,sp,this);
    }

    public abstract void Effect();
}
