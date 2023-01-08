using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notification : MonoBehaviour
{
	#region Singleton
	public static Notification instance;

	private void Awake()
	{
		if (instance == null) { instance = this; }
	}

	#endregion

	public Text noText;
	public GameObject noObject;



	public void ShowNotification(string toShow, float duration)
	{
		StartCoroutine(NotificationSpawn(toShow, duration));
	}

	IEnumerator NotificationSpawn(string toShow, float duration)
	{
		noObject.SetActive(true);
		noText.text = toShow;
		yield return new WaitForSeconds(duration);
		noObject.SetActive(false);
	}

}
