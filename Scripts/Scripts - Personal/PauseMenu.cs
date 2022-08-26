using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    
   public static bool GameIsPaused = false;
   //refrence to the oause
   public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        
        void Resume()
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 0.0f;
            GameIsPaused = false;
        }

        void Pause()
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0.0f;
            GameIsPaused = true;
        }
    }
     //On select button game resumes
        public void OnResumeButton()
        {
            Time.timeScale = 1f;
            pauseMenuUI.SetActive(false);
            GameIsPaused = false;
        }

     // click on menu it brings to main menu
        public void LoadMenu()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Menu");
        }
    //Exits Game
        public void QuitGame()
        {
            Debug.Log("Quiting game...");
            Application.Quit();
        }
    
}
