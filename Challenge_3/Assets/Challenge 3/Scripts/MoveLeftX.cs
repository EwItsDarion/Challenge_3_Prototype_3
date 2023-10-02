/* Darion Jeffries
 * MoveLeftX
 * Challenge 3
 * Makes objects move left
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftX : MonoBehaviour
{
    public float speed = 30f;
    private PlayerControllerX playerControllerScript;
    private float leftBound = 60f;
     

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
    }

    // Update is called once per frame
    void Update()
    {
        // If game is not over, move to the left
        if (!playerControllerScript.gameOver)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
       
        // If object goes off screen that is NOT the background, destroy it
        if (transform.position.x > leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
            print("Destroyed Bomb");
        }
        if (transform.position.x > leftBound && gameObject.CompareTag("Money"))
        {
            Destroy(gameObject);
            print("Destroyed cash");
        }
     
    }
}
