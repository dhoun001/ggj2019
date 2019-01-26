using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunctions : Singleton<MenuFunctions>
{
    [SerializeField]
    private int _maxLevel = 3;

    /// <summary>
    /// Load the next scene level. Don't use on the last level (max level), instead transition to game win scene
    /// </summary>
    public void LoadNextLevel()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        int levelNumber = 1;
        System.Int32.TryParse(sceneName[sceneName.Length - 1].ToString(), out levelNumber);
        string levelSceneName = "Level" + levelNumber.ToString();

        SceneManager.LoadScene("Level" + levelNumber);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
