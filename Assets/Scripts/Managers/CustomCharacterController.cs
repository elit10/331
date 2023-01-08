using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CustomCharacterController : MonoBehaviour
{

    #region Singleton

    public static CustomCharacterController instance;
    public Nutrients playerNutrients;

    private void Awake()
    {
        if (instance == null) { instance = this; }
    }

    #endregion

    [Header("Stats")]
    [Range(0,1)]
    public float speed;


    public void AddNutrients(Nutrients added)
    {
        print(playerNutrients.ToString());
        playerNutrients =  Nutrients.Add(playerNutrients, added);
    }

    //şimdilik
    private void Start()
    {
        GameState.curState = GameState.States.Running;
        playerNutrients = GetComponent<Nutrients>();
        Cursor.lockState = CursorLockMode.Locked;
    }

	private void OnCollisionEnter(Collision collision)
	{
		if (collision == null) { return; }
        if (collision.gameObject.GetComponent<Nutrients>() != null)
        {
            print("removed");
            AddNutrients(collision.gameObject.GetComponent<Nutrients>());
            NPCSpawner.instance.removeFromMap(collision.gameObject);
        }

	}


	private void Update()
    {
        if (Input.GetButtonDown("Tab"))
        {
            GameObject UI = UIManager.instance.UI;

            GameState.curState = UI.activeSelf ? GameState.States.Running : GameState.States.Stopped;
            Cursor.visible = !UI.activeSelf;
            Cursor.lockState = UI.activeSelf ? CursorLockMode.Locked : CursorLockMode.None;


            UI.SetActive(!UI.activeSelf);
        }

        if (GameState.curState == GameState.States.Running)
        {
            Vector3 moveTo = transform.position + (transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal")) * speed;

            moveTo.y = Mathf.Clamp(moveTo.y, -GameManager.instance.maxDept, 0);

            transform.DOMove(moveTo, Time.deltaTime);



            if (Input.GetAxis("Vertical") > 0.5)
            {
                CameraManager.instance.setFov(80);
            }
            else if (Input.GetAxis("Vertical") < -0.5)
            {
                CameraManager.instance.setFov(40);
            }
            else
            {
                CameraManager.instance.setFov(60);
            }
        }
    }




}
