using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{

    // On Button Press Play Game
    public void OnPlayButton()
    {
        SceneManager.LoadScene("Level 0");
    }

    //On Button press Quit Game
    public void OnQuitButton()
    {
        Application.Quit();
    }
}
