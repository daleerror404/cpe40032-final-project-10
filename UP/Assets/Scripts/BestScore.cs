using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{
    public Text highScore;
    void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }


    public void HighScore()
    {
        int number = PlayerController.score;

        if (number > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", number);
            highScore.text = number.ToString();
        }
    }


    // Update is called once per frame
    void Update()
    {
        HighScore();
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        highScore.text = "0";
    }
}
