using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Replay()
    {
        PlayerController.score = 0;
        SceneManager.LoadScene("Game");
      

    }

    public void MainMenu()
    {
        PlayerController.score = 0;
        SceneManager.LoadScene("Main Menu");
    }
}
