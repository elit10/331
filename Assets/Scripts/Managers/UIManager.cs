using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	#region Singleton
	public static UIManager instance;

	private void Awake()
	{
		if (instance == null ) { instance = this; }
	}
	#endregion

	public Panel[] Panels;
	public GameObject UI;

	public EvolutionPanel evolutionPanel;
	public ManagementPanel managementPanel;

	public Text carbs;
	public Text protein;
	public Text fat;

	public Image healthImage;
	public Text health;

	public void OpenUpPanel(int index)
	{
		for (int i = 0; i < Panels.Length; i++)
		{
			if (i == index)
			{
				Panels[i].Activate(true);
			}
			else 
			{
				Panels[i].Activate(false);
			}

		}
	
	}

	public void UpdateUI(Nutrients val)
	{
		carbs.text = val.carbs.ToString();
		protein.text = val.protein.ToString();
		fat.text = val.fat.ToString();

	}

	public void UpdateUI(float val)
	{
		health.text = Mathf.Floor(val).ToString();

		float g = val * 2.55f;
		healthImage.color = new Color(255 - g, g, 0);

	}
}
