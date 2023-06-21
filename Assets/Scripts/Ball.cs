using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Pedal OyunPedali;
    Vector2 diff;
    private Rigidbody2D rb;
    bool isStarted = false;
    


    public TextMeshProUGUI nameText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    int currentScore;

    private float countdownTime;
    private float currentTime;
    
    void Start()
    {

        diff = transform.position - OyunPedali.transform.position;

        rb = GetComponent<Rigidbody2D>();

        UpdateName();
        scoreText.text = "0";
        
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 2)
        {
            currentScore = 0;
            countdownTime = 120f;
        }
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 3)
        {
            currentScore = PlayerPrefs.GetInt("score");
            countdownTime = 240f;
        }
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 4)
        {
            currentScore = PlayerPrefs.GetInt("score");
            countdownTime = 500f;
        }

        currentTime = countdownTime;
    }

    // Update is called once per frame
    void Update()
    {
        MyBall();
        UpdateTimer();
        GetScore();


    }

    private void MyBall()
    {
        
        

        if (Input.GetMouseButtonDown(0) && !isStarted)
        {   
            isStarted = true;
            Firlat(0);

        }
        if(!isStarted)
        {
            BallPedala();
        }

            
    }

    private void BallPedala()
    {
            Vector2 pedPos = new Vector2(OyunPedali.transform.position.x, OyunPedali.transform.position.y);
            transform.position = pedPos + diff;
        
    }

    private void Firlat(int num)
    {
        rb.velocity = new Vector2(3f, 7f);
        rb.AddForce(new Vector2(Random.Range(-1f, 1f), 1).normalized * Time.deltaTime );
    }

    public void UpdateScore()
    {

        // Format the scores into a string
        string scoreString = "";

        currentScore += 1;
        PlayerPrefs.SetInt("score", currentScore);
        scoreString = currentScore.ToString();

        scoreText.text = scoreString;



    }

    public void GetScore()
    {
        string scoreString = "";

        
        PlayerPrefs.SetInt("score", currentScore);
        scoreString = currentScore.ToString();

        scoreText.text = scoreString;
    }

    public void UpdateName()
    {
        nameText.text = PlayerPrefs.GetString("name");
    }


    private void UpdateTimer()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            //int minutes = Mathf.FloorToInt(currentTime / 60);
            int seconds = Mathf.FloorToInt(currentTime);

            timerText.text = seconds.ToString();

            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("box");
            if (objectsWithTag.Length == 0)
            {
                Debug.Log("Win");
                if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 2)
                {
                    UnityEngine.SceneManagement.SceneManager.LoadScene(3);
                }
                if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 3)
                {
                    UnityEngine.SceneManagement.SceneManager.LoadScene(4);
                }
                if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 4)
                {
                    UnityEngine.SceneManagement.SceneManager.LoadScene(5);
                }

            }
        }
        else
        {
            // Timer has ended, do something here
            Debug.Log("Time's up!");
            UnityEngine.SceneManagement.SceneManager.LoadScene(5);
        }
    }


}
