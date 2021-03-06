﻿using System.Collections;
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
        UIController.Instance.RunInProgress();
        Inventory.Instance.display.Disable();
        catBehavior.StartCatMoving();
    }

    public void Restart()
    {
        catBehavior.angryBub.SetActive(false);
        UIController.Instance.inLoseState = false;
        Inventory.Instance.display.Enable();
        GameManager.Instance.RestartRun();
        UIController.Instance.ResetLog();
        catBehavior.RestartCatPosition();
        foreach(Pillow p in FindObjectsOfType<Pillow>())
        {
            p.ResetObject();
        }
        foreach (Vase p in FindObjectsOfType<Vase>())
        {
            p.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    public void NextLevel()
    {
        catBehavior.loveBub.SetActive(false);
        MenuFunctions.Instance.LoadLevel(1);
    }
}
