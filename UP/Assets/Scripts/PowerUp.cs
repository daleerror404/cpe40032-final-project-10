using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public int FinalScore;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("tumama");

        PickUp();

    }

    // Update is called once per frame
    public void PickUp()
    {
        PlayerController.score += 2;
        Destroy(gameObject);
    }
}
