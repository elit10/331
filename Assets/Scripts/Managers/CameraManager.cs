using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraManager : MonoBehaviour
{

    #region Singleton

    public static CameraManager instance;

    private void Awake()
    {
        if (instance == null) { instance = this; cam = GetComponent<Camera>(); }
    }

    #endregion

    public Camera cam;
    private Vector3 oldMousePos;
    public Vector3 mouseDelta;
    public Transform playerTransform;

    [Header("Stats")]
    [Range(0, 50)]
    public float rotationSpeed;


    private void Start()
	{
        playerTransform = CustomCharacterController.instance.transform;
	}

	private void Update()
	{
        if (GameState.curState == GameState.States.Running)
        {
            Vector3 toRotate = new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), mouseDelta.z);
            playerTransform.DORotate(playerTransform.rotation.eulerAngles + toRotate * rotationSpeed, Time.deltaTime);
        }
    }

	public void setFov(float val)
    {
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, val, Time.deltaTime*5);

    }


}
