using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelExplode : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag != "Terrain")
        {
            //Explode
            Destroy(gameObject);
        }
    }
}
