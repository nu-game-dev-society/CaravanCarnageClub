using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelExplode : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent && other.transform.parent.parent && other.transform.parent.parent.tag == "Player")
        {
            //Explode
            Destroy(gameObject);
        }
    }
}
