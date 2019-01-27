using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : Singleton<UIController>
{
    [SerializeField]
    private Image _fadeImage;

    public void ShowWinMessage()
    {
        Color color = _fadeImage.color;
        color.a = 0.5f;
        _fadeImage.color = color;
        //TODO: show win messsage
        //TODO: show next level button, quit to menu button
        //TODO: show good feelings
    }

    public void ShowLoseMessage()
    {
        //TODO: show lose message
        //TODO: flash Restart button
        //TODO: at this point, ensure player cannot win level unless they restart
    }
}
