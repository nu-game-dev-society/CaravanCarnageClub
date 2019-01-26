using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPower : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent && other.transform.parent.parent && other.transform.parent.parent.tag == "Player")
        {
            other.transform.parent.parent.GetComponent<CarSpeedControl>().AddSpeedTime(5);
            Destroy(gameObject);
        }
    }
}
