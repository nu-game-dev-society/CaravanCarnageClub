using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


[RequireComponent (typeof(Rigidbody))]
public class NetworkedCarController : NetworkBehaviour {
    [SerializeField] Transform cVanSpawn;
    [SerializeField] GameObject caravansPrefab;

    [SerializeField] Caravan[] caravanScripts;
    public float m_acceleration;
    public float m_currentSpeed;
    public float m_maxSpeed;
    public float m_TurnSpeed;


    Rigidbody m_Rigidbody;
    Transform m_Transform;

    [SerializeField] Vector3 centreOfMass;

    // Use this for initialization
    void Start ()
    {
        if (!isLocalPlayer)
            return;

        m_TurnSpeed = 0;
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.centerOfMass = centreOfMass;
        m_Transform = GetComponent<Transform>();

        GameObject cVans = Instantiate(caravansPrefab);
        cVans.transform.position = cVanSpawn.position;
        cVans.GetComponent<HingeJoint>().connectedBody = m_Rigidbody;
        cVans.GetComponent<Rigidbody>().centerOfMass = centreOfMass;


    }


    bool IsGrounded()
    {
        RaycastHit hit;

        if (Physics.Raycast(m_Transform.position, -m_Transform.up, out hit))
        {
            if (hit.transform.CompareTag("Floor"))
                return true;
        }
        return false;
    }




    void FixedUpdate()
    {
        if (!isLocalPlayer)
            return;
        if (IsGrounded())
        {
            float v = Input.GetAxis("Vertical");
            float h = Input.GetAxis("Horizontal");
            Vector3 _move = (v * transform.forward);
            Move(_move * m_currentSpeed);

            if (m_Rigidbody.velocity != new Vector3(0, 0, 0))
            {
                m_currentSpeed = Mathf.Lerp(m_currentSpeed, m_maxSpeed, 0.2f * Time.fixedDeltaTime);
                m_TurnSpeed = m_currentSpeed / 1000;
                Rotate();
            }

            if (h == 0)
            {
                m_currentSpeed = Mathf.Lerp(m_currentSpeed, 1000f, 0.2f * Time.fixedDeltaTime);
            }
        }
        else
        {
            print("off floor");
        }

    }

    public void Move(Vector3 move)
    {
        m_Rigidbody.AddForce(move * Time.fixedDeltaTime);
    }



    public void Rotate()
    {
        float tiltAroundY = Input.GetAxis("Horizontal") * Input.GetAxis("Vertical") * m_TurnSpeed;

        Vector3 targetRotation = new Vector3(0, 0, 0);

        if (Input.GetAxis("Horizontal") != 0)
            targetRotation = new Vector3(0, tiltAroundY, 0);



        //transform.Rotate(0, tiltAroundY, 0);
        Quaternion deltaRotation = Quaternion.Euler(targetRotation);
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation);
    }


}
