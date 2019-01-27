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
        StartCoroutine(spawnEnemies());
    }

    private void Update()
    {
        activeEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        
        
    }


    IEnumerator spawnEnemies()
    {
        foreach (GameObject waypoint in SpawnPoints)
        {
            yield return new WaitForSeconds(0.2f);
            if (activeEnemies < maxEnemies)
            {
                Instantiate(enemy, waypoint.transform.position, Quaternion.identity);
            }
        }

        StartCoroutine(spawnEnemies());

    }





}
