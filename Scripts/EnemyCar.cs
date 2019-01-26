using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class EnemyCar : MonoBehaviour {

    [SerializeField] GameObject Waypoint;
    [SerializeField] GameObject myCaravan;

    [SerializeField] WaypointPathfinding wpPf;

   

    private void Start()
    {

    }

    // Update is called once per frame
    void Update () {

        //Waypoint.transform.position = target.position;


	}

    public void Boom()
    {

        Destroy(gameObject.transform.parent.gameObject);
        
    }
}
