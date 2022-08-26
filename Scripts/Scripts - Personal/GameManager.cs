using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int curScore;

    public bool gamePaused;

   // Instance
    public static GameManager instance;

    void Awake()
    {
        //Set the instance to this script
        instance = this;
    }
    void Start()
    {
       Time.timeScale = 1.0f;
     
    }
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

        // Toggle the pause menu & cursor
        GameUI.instance.TogglePauseMenu(gamePaused);
        Cursor.lockState = gamePaused == true ?  CursorLockMode.None : CursorLockMode.Locked;

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
        Time.timeScale = 0.0f;
        gamePaused = true;
    }
}
