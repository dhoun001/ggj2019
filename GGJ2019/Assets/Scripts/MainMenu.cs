using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _mainMenuScreen;

    [SerializeField]
    private GameObject _choosePetScreen;

    public void ChoosePetName()
    {
        _mainMenuScreen.gameObject.SetActive(false);
        _choosePetScreen.gameObject.SetActive(true);
    }

    public void BackToMainMenu()
    {
        _mainMenuScreen.gameObject.SetActive(true);
        _choosePetScreen.gameObject.SetActive(false);
    }

    public void LoadLevel()
    {
        MenuFunctions.Instance.LoadNextLevel();
    }

    public void QuitGame()
    {
        MenuFunctions.Instance.QuitGame();
    }
}
