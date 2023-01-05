using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PPManager : MonoBehaviour
{

    #region Singleton

    public static PPManager instance;

    private void Awake()
    {
        if (instance == null) { instance = this;}
    }

    #endregion


    public PostProcessProfile profile;
    public Transform playerTransform;

	private void Start()
	{
        playerTransform = CustomCharacterController.instance.transform;
	}


	public void ChangeDept()
    { 
        
    
    }


}
