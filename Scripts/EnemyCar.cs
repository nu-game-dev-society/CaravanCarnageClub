using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class EnemyCar : MonoBehaviour {

    [SerializeField] Transform[] waypoints;
    [SerializeField] CarAIControl AIControl;
    [SerializeField] GameObject Waypoint;

    Transform target;
    float distToTarget;

    private void Start()
    {
        AIControl = gameObject.GetComponent<CarAIControl>();
        target = waypoints[(Random.Range(0, waypoints.Length))];
    }

    // Update is called once per frame
    void Update () {

        Waypoint.transform.position = target.position;

        if (target != null)
        {
            target = AIControl.getTarget();
            distToTarget = Vector3.Distance(target.position, transform.position);
        }
        

        if (distToTarget <= 5 || target == null)
        {
            target = waypoints[(Random.Range(0, waypoints.Length))];
        }


	}
}
