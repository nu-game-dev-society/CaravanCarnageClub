using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPathfinding : MonoBehaviour {

    [SerializeField] GameObject[] waypoints;
    public Transform myTransform;
    public Transform target;

    public float distToTarget;

    public Transform myCar;


    [SerializeField] NavMeshAgent pathfinder;

	// Use this for initialization
	void Start () {
        pathfinder = gameObject.GetComponent<NavMeshAgent>();
        waypoints = GameObject.FindGameObjectsWithTag("Waypoints");
        target = waypoints[(Random.Range(0, waypoints.Length))].transform;
        UpdatePath();
	}
	
	// Update is called once per frame
	void Update () {
        pathfinder.SetDestination(target.position);

        

        if (target != null)
        {
            distToTarget = Vector3.Distance(target.position, transform.position);
        }


        if (distToTarget <= 5 || target == null)
        {
            target = waypoints[(Random.Range(0, waypoints.Length))].transform;
        }

    }

    IEnumerator UpdatePath()
    {
        float refreshRate = 5f;

        while (target != null)
        {
                pathfinder.SetDestination(target.position);
                pathfinder.speed = 25;

           
            yield return new WaitForSeconds(refreshRate);
        }

        yield return new WaitForSeconds(3);
      
        StartCoroutine(UpdatePath());
    }
}
