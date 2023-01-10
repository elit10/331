using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notification : MonoBehaviour
{
	#region Singleton
	public static Notification instance;

	public bool isNotifying = false;

	private void Awake()
	{
		if (instance == null) { instance = this; }
	}

	#endregion

	public Text noText;
	public GameObject noObject;



	public void ShowNotification(string toShow, float duration)
	{
		if (!isNotifying) { StartCoroutine(NotificationSpawn(toShow, duration)); }
	}

	IEnumerator NotificationSpawn(string toShow, float duration)
	{
		isNotifying = true;
		noObject.SetActive(true);
		noText.text = toShow;
		yield return new WaitForSeconds(duration);
		noObject.SetActive(false);
		isNotifying = false;
	}

}
