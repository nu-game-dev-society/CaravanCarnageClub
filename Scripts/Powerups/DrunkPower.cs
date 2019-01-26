using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrunkPower : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.parent.tag == "Player")
        {
            Camera.main.GetComponent<Drunk>().drunk = true;
            Camera.main.GetComponent<Drunk>().AddDrunkTime(5);
            Destroy(gameObject);
        }        
    }
}
