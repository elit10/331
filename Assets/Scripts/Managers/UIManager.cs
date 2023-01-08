using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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



}
