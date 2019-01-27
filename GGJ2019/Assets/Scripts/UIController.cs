﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : Singleton<UIController>
{
    [SerializeField]
    private Image _fadeImage;
    [SerializeField]
    private Text _messegeLog;
    [SerializeField]
    private Button _leaveLevelButton;
    [SerializeField]
    private Button _restartButton;

    public bool inLoseState = false;

    public void Fade(float a)
    {
        Color color = _fadeImage.color;
        color.a = a;
        _fadeImage.color = color;
    }

    public void ShowWinMessage()
    {
        if (inLoseState)
            return;

        Fade(0.5f);
        //TODO: show win messsage
        _messegeLog.text = "Level Complete!";
        //TODO: show next level button, quit to menu button
        _leaveLevelButton.gameObject.SetActive(true);
        _restartButton.interactable = false;
        //TODO: show good feelings
    }

    public void ShowLoseMessage()
    {
        //TODO: show lose message
        _messegeLog.text = "Uh oh! Press Restart!";
        //TODO: flash Restart button
        //TODO: at this point, ensure player cannot win level unless they restart
        inLoseState = true;
    }
}
