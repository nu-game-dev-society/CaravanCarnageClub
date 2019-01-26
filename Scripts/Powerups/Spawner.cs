using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    int maxPowerups = 1;
    int powerupCount = 0;

    [SerializeField]
    GameObject[] powerups;

    float nextActionTime = 0.0f;

    [SerializeField]
    float period = 10;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;

            powerupCount = transform.childCount;

            if (powerupCount < maxPowerups)
            {
                SpawnPower();
            }
        }
    }

    void SpawnPower()
    {
        while (powerupCount < maxPowerups)
        {
            GameObject powerup = powerups[Random.Range(0, powerups.Length)];

            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), 0));

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Terrain")
                {
                    GameObject tmpBarrel = GameObject.Instantiate(powerup);
                    tmpBarrel.transform.SetParent(transform);
                    tmpBarrel.transform.position = hit.point;

                    powerupCount++;
                }
            }
        }
    }
}
