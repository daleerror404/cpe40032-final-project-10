using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour


{
    public Vector3 force;
    public GameObject GatePrefab;
    public GameObject CubePrefab;
    public GameObject PowerUpPrefab;
    public static int score = 0;
    public Text highScore;
    public Text scoreText;
    public AudioSource sfx;
    public AudioClip[] sfxList;



    bool isDead = false;
    Vector3 camPos;

    Rigidbody2D rb2d;
    ShakeCamera camShaker;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        camShaker = GetComponent<ShakeCamera>();

        float halfScreenWidthInUnits = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0)).x - 2f;

        Vector3 deltaPos = Vector3.up * 10f;
        Vector3 prevPos = Vector3.zero;
        Vector3 curPos = Vector3.zero;
        Vector3 cubePos = Vector3.zero;
        Vector3 cube1Pos = Vector3.zero;
        Vector3 powerPos;
        Vector3 deltapowerPos = Vector3.up * Random.Range(15f, 25f);
        Vector3 prevpowerPos = Vector3.zero;



        for (int i = 1; i < 100; i++)
        {
            //aleth: generate new gate
            curPos = prevPos + deltaPos;
            curPos = new Vector3(Random.Range(-halfScreenWidthInUnits, halfScreenWidthInUnits), curPos.y, 0);
            cubePos = new Vector3(curPos.x + Random.Range(0f, 3f), curPos.y + Random.Range(2f, 3f));

            cube1Pos = new Vector3(curPos.x + Random.Range(0f, 3f), curPos.y - Random.Range(2f, 3f));

            powerPos = prevpowerPos + deltapowerPos;
            powerPos = new Vector3(cubePos.x + Random.Range(-4f, 5f), curPos.y + Random.Range(4f, 6f));

            Instantiate(PowerUpPrefab, powerPos, Quaternion.identity);
            

            //aleth: small obstacle random position
            Instantiate(CubePrefab, cubePos, Quaternion.identity);

            
            Instantiate(CubePrefab, cube1Pos, Quaternion.identity);


            Instantiate(GatePrefab, curPos, Quaternion.identity);


            prevPos = new Vector3(0, curPos.y);


        }

       


    }

    public void HighScore()
    {
        int number = score;

        if (number > PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore", number);
            highScore.text = number.ToString();
        }
    }



    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        //aleth: game will reset once the player died
       

        Vector3 curPos = Camera.main.WorldToScreenPoint(transform.position);

        if (curPos.x > Screen.width - 10 || curPos.x < 10)
        {
            rb2d.velocity = new Vector3(
                Mathf.Abs(rb2d.velocity.x) * ((curPos.x < 10) ? 1 : -1),
                rb2d.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || (Input.GetKeyDown(KeyCode.LeftArrow)))

        {
            sfx.PlayOneShot(sfxList[0]);

            //aleth: ball will have gravity
            if (rb2d.isKinematic)
                rb2d.isKinematic = false;

            rb2d.velocity = Vector3.zero;
            rb2d.angularVelocity = 0f;

            //aleth: angle of the ball based on where the player has clicked
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                rb2d.AddForce(force, ForceMode2D.Impulse);
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                rb2d.AddForce(new Vector3(-force.x, force.y), ForceMode2D.Impulse);
            }

        }

  



        //aleth: when the ball hits the bottom
        if (curPos.y < 10)
        {
            Die();
            GameOver();
        }

        MoveCamera();


    }

    void AfterFixedUpdate()
    {
        Debug.Log("hey");
    }

    void Die()
    {
        isDead = true;
        camShaker.Shake();
        StartCoroutine("DisableCollider");
        scoreText.text = score.ToString();
        sfx.PlayOneShot(sfxList[2]);
        Debug.Log("Score: " + score);
        HighScore();


    }

    


    void GameOver()
    {
        StartCoroutine(goToGameOver());
       // score = 0;
    }

    IEnumerator goToGameOver()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Game Over");

    }

    IEnumerator DisableCollider()
    {
        yield return new WaitForFixedUpdate();
        yield return new WaitForFixedUpdate();
        yield return new WaitForFixedUpdate();
        GetComponent<Collider2D>().enabled = false;
    }

    //aleth: dies once collided to an obstacle
    void OnCollisionEnter2D(Collision2D col)
    {
        Die();
        GameOver();
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        col.enabled = false;
        score++;
        //best++;
        scoreText.text = score.ToString();
        sfx.PlayOneShot(sfxList[1]);
        Debug.Log(score);
    }


    //aleth: camera movement
    void MoveCamera()
    {
        camPos = Camera.main.transform.position;

        if (transform.position.y > camPos.y)
        {
            Camera.main.transform.position = new Vector3(camPos.x, transform.position.y, camPos.z);
        }
    }

}
