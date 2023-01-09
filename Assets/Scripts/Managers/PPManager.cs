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
    public ColorGrading cg;

    public bool eyes;

	private void Start()
	{
        playerTransform = CustomCharacterController.instance.transform;
        cg = profile.GetSetting<ColorGrading>();
    }

	private void Update()
	{
        if (eyes)
        {
            if (cg.postExposure == 1) { return; }
            cg.postExposure.value = 1;
        }
        else
        {
            UpdateDept();
        }
	}

	public void UpdateDept()
    {
        cg.postExposure.value = playerTransform.position.y / (GameManager.instance.maxDept/5);
    
    }


}
