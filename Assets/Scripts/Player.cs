using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    string name;
    int lastScore;
    int[] Scores = new int[5];
    //int firstTime = 1;
    

    //get 5 textmeshpro objects and assign them to the scores
    public TextMeshProUGUI scoreLast;
    public TextMeshProUGUI score1;
    public TextMeshProUGUI score2;
    public TextMeshProUGUI score3;
    public TextMeshProUGUI score4;

    public TextMeshProUGUI nameText;


    public Button btn;
    


    public TMP_InputField inputField;

    private void Start()
    {   // if this scene is number 0 then the player name will be saved
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 0)
        {   
            btn.onClick.AddListener(SavePlayerName);
        }

        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 5 || UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 6)
        {   
            
            SaveScore();
            PrintScore();
            PrintName();
        }

    }


    public void SavePlayerName()
    {
        name = inputField.text;
        PlayerPrefs.SetString("name", name);
        Debug.Log(name);
    }

    // store last 5 scores in an array and make the currentscore the first element of the array and slide other and make the last element dissapear

    public void SaveScore()
    {
        lastScore = PlayerPrefs.GetInt("score");
        

        Scores[0] = PlayerPrefs.GetInt("last");
        Scores[1] = PlayerPrefs.GetInt("1");
        Scores[2] = PlayerPrefs.GetInt("2");
        Scores[3] = PlayerPrefs.GetInt("3");
        Scores[4] = PlayerPrefs.GetInt("4");

        for (int i = 4; i > 0; i--)
        {
            Scores[i] = Scores[i-1];

        }

          

        Scores[0] = lastScore;

        
        PlayerPrefs.SetInt("last", Scores[0]);
        PlayerPrefs.SetInt("1", Scores[1]);
        PlayerPrefs.SetInt("2", Scores[2]);
        PlayerPrefs.SetInt("3", Scores[3]);
        PlayerPrefs.SetInt("4", Scores[4]);


    }

    public void PrintScore()
    {
        scoreLast.text = Scores[0].ToString();
        score1.text = Scores[1].ToString();
        score2.text = Scores[2].ToString();
        score3.text = Scores[3].ToString();
        score4.text = Scores[4].ToString();

    }

    public void PrintName()
    {
        nameText.text = PlayerPrefs.GetString("name");
    }
}
