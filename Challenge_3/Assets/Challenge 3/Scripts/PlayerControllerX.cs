/* Darion Jeffries
 * PlayerControllerX
 * Challenge 3
 * Adds controls to player
 */
using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerControllerX : MonoBehaviour
{
    public ScoreManager scoreManager;
    public bool gameOver = false;
   

    public ForceMode jumpForceMode;
    public float floatForce;
    private float gravityModifier = 1.7f;
    private Rigidbody playerRb;
    public bool isOnGround = false;
    public bool isTooHigh = false;
    

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        jumpForceMode = ForceMode.Impulse;
        if (Physics.gravity.y > -10)
        {
            Physics.gravity *= gravityModifier;
        }
        playerAudio = GetComponent<AudioSource>();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        // While space is pressed and player is low enough, float up
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver && !isTooHigh)
        {
            playerRb.AddForce(Vector3.up * floatForce, jumpForceMode);
            
        }
        if (transform.position.y >= 16)
        {
            isTooHigh = true;
        }
        if (transform.position.y < 16)
        {
            isTooHigh = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            playerRb.AddForce(Vector3.up * floatForce, jumpForceMode);
        }
        else
        {
            isOnGround = false;
        }
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Obstacle"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }

    }

}
