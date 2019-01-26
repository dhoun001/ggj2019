using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCommands : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            MenuFunctions.Instance.LoadLevel(-1);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            MenuFunctions.Instance.LoadLevel(1);
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            MenuFunctions.Instance.LoadMainMenuScene();
        }
    }
}
