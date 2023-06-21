using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update

    private float speed = 90f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // move canvas to up with speed after 18 second game start
        if (Time.timeSinceLevelLoad > 18f)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }

        // go to next scene after 40 second after game start using scene manager

        if (Time.timeSinceLevelLoad > 50f)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }



        
        
        
    }
}
