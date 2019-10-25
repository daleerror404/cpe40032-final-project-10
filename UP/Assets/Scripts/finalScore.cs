using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finalScore : MonoBehaviour
{ 
    public Text FinalScore;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        FinalScore.text = PlayerController.score.ToString();

    }

   
}
