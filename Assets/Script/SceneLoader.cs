using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private Score score;

    private void Start()
    {
        score = FindObjectOfType<Score>();
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
    public void GameOver()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadMainScene()
    {
        SceneManager.LoadScene(0);
        score.Reset();
    }
    public void ShutDown()
    {
        Application.Quit();
    }
    public void WinScene()
    {
        SceneManager.LoadScene(3);
    }
}
