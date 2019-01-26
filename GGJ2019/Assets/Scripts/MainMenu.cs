using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
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
        GameManager.Instance.petName = _petNameInput.text;
    }

    public void LoadNext()
    {
        MenuFunctions.Instance.LoadLevel(1);
    }

    public void QuitGame()
    {
        MenuFunctions.Instance.QuitGame();
    }
}
