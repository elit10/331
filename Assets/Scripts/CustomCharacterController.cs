using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CustomCharacterController : MonoBehaviour
{

    #region Singleton

    public static CustomCharacterController instance;

    private void Awake()
    {
        if (instance == null) { instance = this; }
    }

    #endregion

    [Header("Stats")]
    [Range(0,1)]
    public float speed;

    //şimdilik
    private void Start()
    {
        GameState.curState = GameState.States.Running;
    }

    private void Update()
    {
        if (GameState.curState == GameState.States.Running)
        {
            transform.DOMove(transform.position + transform.forward * Input.GetAxis("Vertical") * speed, Time.deltaTime);

        }
    }




}
