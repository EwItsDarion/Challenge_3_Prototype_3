/* Darion Jeffries
 * SpawnManager
 * Prototype 3
 * Manages spawn rates
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject triggerzonePrefab;
    private Vector3 spawnPosition = new Vector3(25, 0, 0);
    private Vector3 spawnPositionTriggerZ = new Vector3(25, 10, 0);

    private float startDelay = 2;
    private float repeatRate = 2;

    private PlayerController playerControllerScript;

    void Start()
    {
        playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    void SpawnObstacle()
    {
        if (!playerControllerScript.gameOver)
        {
            Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
            Instantiate(triggerzonePrefab, spawnPositionTriggerZ, triggerzonePrefab.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
