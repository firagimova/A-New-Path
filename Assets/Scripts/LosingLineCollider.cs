using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LosingLineCollider : MonoBehaviour
{
    
    

    //If our object collides the object with tag "ball" restart the scene
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(5);
        }
    }
}
