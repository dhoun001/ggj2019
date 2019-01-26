using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunctions : Singleton<MenuFunctions>
{
    /// <summary>
    /// Load the next or prev scene level. Pass in the CHANGE in the level, not the level to move to
    /// </summary>
    public void LoadLevel(int diff)
    {
        string sceneName = SceneManager.GetActiveScene().name;
        int levelNumber = 1;
        bool currentSceneIsLevel = System.Int32.TryParse(sceneName[sceneName.Length - 1].ToString(), out levelNumber);
        levelNumber += diff;
        if (levelNumber >= GameManager.Instance.MaxLevel || levelNumber <= 0)
        {
            LoadMainMenuScene();
            return;
        }

        string levelSceneName = "Level" + levelNumber.ToString();
        GameManager.Instance.CurrentLevel = levelNumber;
        SceneManager.LoadScene(levelSceneName);
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
