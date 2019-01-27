using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFunctions : Singleton<LevelFunctions>
{
    public void Play()
    {
        GameManager.Instance.StartRun();
    }

    public void Restart()
    {
        GameManager.Instance.RestartRun();
    }

    public void NextLevel()
    {
        MenuFunctions.Instance.LoadLevel(1);
    }
}
