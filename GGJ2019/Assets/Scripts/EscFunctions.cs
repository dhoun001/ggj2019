using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscFunctions : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuFunctions.Instance.QuitGame();
        }
    }
}
