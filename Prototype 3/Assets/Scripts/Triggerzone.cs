/* Darion Jeffries
 * Triggerzone
 * Prototype 3
 * Adds to score if in trigger zone
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggerzone : MonoBehaviour
{

    private UIManagerScript UIManager;

    private bool triggered = false;
    // Start is called before the first frame update
    void Start()
    {
        UIManager = GameObject.FindObjectOfType<UIManagerScript>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;
            UIManager.score++;
            Debug.Log("Added score");
        }
    }
}
