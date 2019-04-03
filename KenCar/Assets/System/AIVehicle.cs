using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Vehicle))]
public class AIVehicle : MonoBehaviour
{

    Vehicle m_Vehicle;

    public enum BrakeCondition { NEVER_BREAK, TARGETDISTANCE }
    public BrakeCondition brakeCondition;
    [Tooltip("Target Brake Distance if Brake Condition")] [SerializeField] float targetBreakDistance;


    Rigidbody m_rigidbody;

    public Transform target;
    float dirNum;

    // Use this for initialization
    void Start()
    {
        m_Vehicle = GetComponent<Vehicle>();
        m_Vehicle.controllable = false;

        m_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
            DriveTowardsTarget();
    }


    void DriveTowardsTarget()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        float accel = 1;

        Vector3 heading = target.position - transform.position;
        dirNum = AngleDir(transform.forward, heading, transform.up);

        if (distanceToTarget > 10)
            m_Vehicle.speed = m_Vehicle.acceleration * accel;
        else
            m_Vehicle.speed = 0;

        if (dirNum != 0)
        {
            if(!CollisionCheck())
                m_Vehicle.RotateCar(dirNum, accel);
            else
                m_Vehicle.RotateCar(obsitlceDirection, accel);
        }
    }

    float AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up)
    {
        Vector3 perp = Vector3.Cross(fwd, targetDir);
        float dir = Vector3.Dot(perp, up);

        if (dir > 0f)
        {
            return 1f;
        }
        else if (dir < 0f)
        {
            return -1f;
        }
        else
        {
            return 0f;
        }
    }

    [SerializeField]Transform[] raycastPoints;
    float obsitlceDirection;

    //Checks if player is moving into an object. 
    public bool CollisionCheck()
    {
        Vector3 raycastPos = transform.position;

        foreach(Transform point in raycastPoints)
        {
  
            Debug.DrawRay(point.position, point.forward * 15, Color.red);
            Ray ray = new Ray(point.position, point.forward);
            RaycastHit hit;
            float shotDistance = 15f;
            if (Physics.Raycast(ray, out hit, shotDistance))
            {
                obsitlceDirection = AngleDir(transform.forward, hit.point, transform.up);

                if (obsitlceDirection == 0)
                    obsitlceDirection = 1;
                else
                    obsitlceDirection *= 1;


                shotDistance = hit.distance;
                Debug.Log(hit.transform.name);
                return true;
            }
        }


        return false;
    }
}
