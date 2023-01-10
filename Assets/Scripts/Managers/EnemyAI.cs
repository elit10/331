using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class EnemyAI : MonoBehaviour
{
	private Transform playerTransform;



	private void Start()
	{
		InvokeRepeating("Loop",0,1f);

		playerTransform = CustomCharacterController.instance.transform;
	}

	public void Loop()
	{
		//track the player if near

		if (Vector3.Distance(transform.position, playerTransform.position) > 30)
		{
			return;
		}
		if (Vector3.Distance(CustomCharacterController.instance.transform.position, transform.position) > GameManager.instance.despawnDistance*1.5f)
		{
			NPCSpawner.instance.removeFromMap(gameObject);
		}
		if (Vector3.Distance(transform.position, playerTransform.position) <5)
		{
			CustomCharacterController.instance.health -= 5;
		}


		Vector3 target = playerTransform.position - transform.position;

		//follow
		transform.DOMove(transform.position + target.normalized * 3, 1f);

		transform.LookAt(playerTransform.position);
	
	}

}
