using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftX : MonoBehaviour
{
    public float speed = 30f;
    private PlayerControllerX playerControllerScript;
    private float leftBound = 30;
     

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
    }

    // Update is called once per frame
    void Update()
    {
        // If game is not over, move to the left
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        // If object goes off screen that is NOT the background, destroy it
        if (transform.position.x > leftBound && !gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
        if (transform.position.x > leftBound && gameObject.CompareTag("Triggerzone"))
        {
            Destroy(gameObject);
        }
    }
}
