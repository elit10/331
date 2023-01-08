using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Evolution : MonoBehaviour
{
    public string ID;
    public Nutrients value;
    public bool isActive;

    public string details;
    public EvolutionPanel ep;

	public void Start()
	{
        ep = UIManager.instance.evolutionPanel;
	}

	public bool isEnough(Nutrients val)
    {
        bool toReturn = true;

        if (val.carbs < value.carbs) { toReturn = false; }

        if (val.fat < value.fat) { toReturn = false; }

        if (val.protein < value.protein) { toReturn = false; }

        return toReturn;
    }

    public int Buy(Nutrients source)
    {
        if (isActive) { return 1; }

        if (isEnough(source))
        {
            isActive = true;
            source =  Nutrients.Remove(source, value);
            return 0;
        }
    
        return 2;
    }

    public void ShowDetails()
    {
        ep.ShowDetails(details);
    }

    public abstract void Effect();
}
