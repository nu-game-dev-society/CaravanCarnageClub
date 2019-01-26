using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject[] SpawnPoints;

    public GameObject enemy;

    public int activeEnemies;
    public int maxEnemies;

    public void Start()
    {
        SpawnPoints = GameObject.FindGameObjectsWithTag("Waypoints");
    }

    private void Update()
    {
        activeEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;

        foreach (GameObject waypoint in SpawnPoints)
        {
            if (activeEnemies < maxEnemies)
            {
                Instantiate(enemy, waypoint.transform.position, Quaternion.identity);

            }
        }
    }






}
