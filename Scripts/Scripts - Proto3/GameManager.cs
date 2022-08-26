using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int scoreToWin;
    public int curScore;

    public bool gamePaused;

    //Instance
    public static GameManager instance;

    void Awake()
    {
        //set the instance to this script
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            TogglePauseGame();
        }
    }
    public void TogglePauseGame()
    {
        gamePaused = !gamePaused;
        Time.timeScale = gamePaused == true ? 0.0f : 1.0f;

        //Toggle the pause menu & Cursor
        GameUI.instance.TogglePauseMenu(gamePaused);
        Cursor.lockState = gamePaused == true? CursorLockMode.None : CursorLockMode.Locked;

    }

    public void AddScore(int score)
    {
        curScore += score;
        // long version curScore = curScore + score;
        //Update score text
        GameUI.instance.UpdateScoreText(curScore);

        // Do we have enough points to win
        if(curScore >= scoreToWin)
            WinGame();

    }
    void WinGame()
    {
        //Show win screen
        GameUI.instance.SetEndGameScreen(true, curScore);

    }

    public void LoseGame()
    {
        //Load and set end game screen
        GameUI.instance.SetEndGameScreen(false, curScore);
        Time.timeScale =0.0f;
        gamePaused = true;
    }
}
