using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFunctions : Singleton<LevelFunctions>
{
    private catBehavior catBehavior;

    private void Awake()
    {
        catBehavior = GameObject.FindGameObjectWithTag("Player").GetComponent<catBehavior>();
    }

    public void Play()
    {
        GameManager.Instance.StartRun();
        catBehavior.StartCatMoving();
    }

    public void Restart()
    {
        UIController.Instance.inLoseState = false;
        GameManager.Instance.RestartRun();
        catBehavior.RestartCatPosition();
    }

    public void NextLevel()
    {
        MenuFunctions.Instance.LoadLevel(1);
    }
}
