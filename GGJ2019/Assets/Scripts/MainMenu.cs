﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private string _defaultPetName = "Mackerel";

    [SerializeField]
    private GameObject _mainMenuScreen;

    [SerializeField]
    private GameObject _choosePetScreen;

    [SerializeField]
    private InputField _petNameInput;

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

    public void SetPetName()
    {
        string petName = _petNameInput.text;
        if (petName == "")
        {
            petName = _defaultPetName;
        }
        GameManager.Instance.petName = petName;
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadNext()
    {
        MenuFunctions.Instance.LoadLevel(1);
        GameManager.Instance.PlayTrack();
    }

    public void QuitGame()
    {
        MenuFunctions.Instance.QuitGame();

    }
}
