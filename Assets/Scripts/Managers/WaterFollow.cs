using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFollow : MonoBehaviour
{
	public Transform playerTransform;

	private void Start()
	{
		playerTransform = CustomCharacterController.instance.transform;
	}


	private void Update()
	{
		Vector3 transformVector = playerTransform.position;

		transform.position = new Vector3(transformVector.x, transform.position.y, transformVector.z);
	}
}
