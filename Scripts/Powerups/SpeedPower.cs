using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPower : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // TODO: Speed car up
        GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<CarSpeedControl>().AddSpeedTime(5);
        Destroy(gameObject);
    }
}
