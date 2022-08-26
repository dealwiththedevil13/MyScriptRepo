using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [Header("End Game Screen")]
    public GameObject endGameScreen;
    public TextMeshProUGUI endGameHeaderText;
    public TextMeshProUGUI endGameScoreText;

    
    [Header("Pause Menu")]
    public GameObject pauseMenu;

    //Instance/ Singleton
    public static GameUI instance;

    void Awake()
    {
        //Set instance to this script
        instance = this;
    }

    public void TogglePauseMenu (bool paused)
     {
        pauseMenu.SetActive(paused);
     }
    public void SetEndGameScreen (bool won, int score)
    {
        endGameScreen.SetActive(true);
        //Changes Header Text
        endGameHeaderText.text = won == true ? "You Win" : "You Lose";
        //Changes the color based on win or lose
        endGameHeaderText.color = won == true ? Color.green : Color.red;
    }

    public void ResumeButton()
    {
        GameManager.instance.TogglePauseGame();
    
    }
    public void OnRestartButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnMenuButton()
    {
        SceneManager.LoadScene("Menu");
    }

    // Update is called once per frame
    void Update()
    {
        SceneManager.LoadScene("Game");
    }
}
