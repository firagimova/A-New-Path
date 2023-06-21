using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    //public Player player;

    //load next scene
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    

    // load the scene with index 3
    public void Restart()
    {
        //player.SavePlayerName();
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    public void StartButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    // quit the game

    public void Quit()
    {
        PlayerPrefs.SetInt("last", 0);
        PlayerPrefs.SetInt("1", 0);
        PlayerPrefs.SetInt("2", 0);
        PlayerPrefs.SetInt("3", 0);
        PlayerPrefs.SetInt("4", 0);


        Application.Quit();
    }
    
    
}
