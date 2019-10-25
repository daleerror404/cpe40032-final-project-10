using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool GameisPaused = false;
    public GameObject PauseMenu;

    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space))
        {
            if (GameisPaused) 
            {
                ResumeGame();

            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
    }

    void PauseGame()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }





}
