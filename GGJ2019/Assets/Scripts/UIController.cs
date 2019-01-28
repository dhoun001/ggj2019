using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : Singleton<UIController>
{
    [SerializeField]
    private AudioClip winAudio;

    [SerializeField]
    private AudioClip loseAudio;

    [SerializeField]
    private Image _fadeImage;
    [SerializeField]
    private Text _messegeLog;
    [SerializeField]
    private Button _leaveLevelButton;
    [SerializeField]
    private Button _restartButton;

    public bool inLoseState = false;
    private catBehavior catBehavior;

    private void Awake()
    {
        catBehavior = GameObject.FindGameObjectWithTag("Player").GetComponent<catBehavior>();
    }

    public void ResetLog()
    {
        _messegeLog.text = "";
    }

    public void Fade(float a)
    {
        Color color = _fadeImage.color;
        color.a = a;
        _fadeImage.color = color;
    }

    public void RunInProgress()
    {
        _messegeLog.text = GameManager.Instance.petName + " is moving!";
    }

    public void ShowWinMessage()
    {
        if (inLoseState)
            return;

        Fade(0.5f);
        catBehavior.HaltCat();
        catBehavior.loveBub.gameObject.SetActive(true);
        //TODO: show win messsage
        _messegeLog.text = "Level Complete!";
        //TODO: show next level button, quit to menu button
        _leaveLevelButton.gameObject.SetActive(true);
        _restartButton.interactable = false;
        GetComponent<AudioSource>().clip = winAudio;
        GetComponent<AudioSource>().Play();
        //TODO: show good feelings
    }

    public void ShowLoseMessage()
    {
        //TODO: show lose message
        _messegeLog.text = "Uh oh! Press Restart!";
        catBehavior.HaltCat();
        catBehavior.angryBub.gameObject.SetActive(true);
        //TODO: flash Restart button
        //TODO: at this point, ensure player cannot win level unless they restart
        inLoseState = true;
        GetComponent<AudioSource>().clip = loseAudio;
        GetComponent<AudioSource>().Play();
        _restartButton.GetComponent<PulseObject>().Pulse();

    }
}
