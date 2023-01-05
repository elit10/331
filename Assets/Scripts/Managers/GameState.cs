using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public enum States
    {
        Running,
        Stopped

    };

    public static States curState;

}
