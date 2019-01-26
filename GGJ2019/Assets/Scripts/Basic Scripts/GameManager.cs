using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public string petName = "Pet Name";

    public void StartRun()
    {
        //TODO: disable inventory
        //TODO: start cat movement
    }

    public void RestartRun()
    {
        //TODO: return all inventory items to hotbar
        //TODO: Reset cat to starting position
        //TODO: reset all other prop data
    }
}
