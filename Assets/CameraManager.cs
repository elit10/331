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



    public void setFov(float val)
    {
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, val, Time.deltaTime*5);

    }


}
