using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    //On the press of the play button The Game begins
  public void OnPlayButton()
  {
      SceneManager.LoadScene("My Game");
  }

    //Can leave game after seleccting the Quit button
  public void OnQuitButton()
  {
      Application.Quit();
  }
}
