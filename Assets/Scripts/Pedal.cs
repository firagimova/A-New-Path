using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedal : MonoBehaviour
{
    [SerializeField] float ekranGenisligiUnitCinsinden = 16f;

    void Start()
    {

    }

    void Update()
    {
        float farePozUnitCinsinden = Input.mousePosition.x / Screen.width * ekranGenisligiUnitCinsinden;
        // Adjust the value so that it's centered around zero
        farePozUnitCinsinden -= ekranGenisligiUnitCinsinden / 2;

        Vector2 pedalPozisyonu = new Vector2(farePozUnitCinsinden, transform.position.y);

        float minX = ekranGenisligiUnitCinsinden / 2 * -1;
        float maxX = ekranGenisligiUnitCinsinden / 2;
        pedalPozisyonu.x = Mathf.Clamp(farePozUnitCinsinden, minX, maxX);

        transform.position = pedalPozisyonu;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("powerup"))
        {
            Debug.Log("Powerup collected");
            // Extend the paddle by the extendAmount
            Vector3 currentScale = transform.localScale;
            transform.localScale = new Vector3(currentScale.x + 1, currentScale.y, currentScale.z);

            // Start the timer to reduce the paddle size after the duration
            StartCoroutine(ResetPaddleSize(transform));
            Destroy(collision.gameObject);
        }

        
    }


    IEnumerator ResetPaddleSize(Transform paddleTransform)
    {
        yield return new WaitForSeconds(5);

        // Reset the paddle size to its original scale
        Vector3 originalScale = paddleTransform.localScale;
        paddleTransform.localScale = new Vector3(originalScale.x - 1, originalScale.y, originalScale.z);
    }


}
