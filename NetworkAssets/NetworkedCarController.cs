using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


[RequireComponent (typeof(Rigidbody))]
public class NetworkedCarController : NetworkBehaviour {
    [SerializeField] Transform cVanSpawn;
    [SerializeField] GameObject caravansPrefab;


    LinkedList<Caravan> caravanScripts= new LinkedList<Caravan>();
    public float m_currentSpeed;
    public float m_maxSpeed;
    public float m_TurnSpeed;

    [Header("Last Caravan Shit")]
    [SerializeField] Transform nextSpawn;
    [SerializeField] Rigidbody nextRB;
    public int caravanCount;


    Rigidbody m_Rigidbody;
    Transform m_Transform;
    float playerHeight;
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
        playerHeight = GetComponent<BoxCollider>().size.y / 2 + 2f;
        nextSpawn = cVanSpawn;
        nextRB = m_Rigidbody;
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
        if (Input.GetKeyDown(KeyCode.L))
            SpawnCaravan();

    }

    public void Move(Vector3 move)
    {
        m_Rigidbody.AddForce(move * Time.fixedDeltaTime);
    }



    public void Rotate()
    {
        float tiltAroundY = Input.GetAxis("Horizontal") * Input.GetAxis("Vertical") * (m_TurnSpeed/((caravanCount + 1)*2));

        Vector3 targetRotation = new Vector3(0, 0, 0);

        if (Input.GetAxis("Horizontal") != 0)
            targetRotation = new Vector3(0, tiltAroundY, 0);



        //transform.Rotate(0, tiltAroundY, 0);
        Quaternion deltaRotation = Quaternion.Euler(targetRotation);
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation);
    }
    bool IsGrounded()
    {
        RaycastHit hit;
        if (Physics.Raycast(m_Transform.position, -m_Transform.up, out hit, playerHeight))
        {
            if (hit.transform.CompareTag("Floor"))
                return true;
        }
        return false;
    }
    void SpawnCaravan()
    {
        GameObject cVans = Instantiate(caravansPrefab);
        
        //cVans.transform.position = nextSpawn.position;
        cVans.transform.rotation = transform.rotation;

        cVans.GetComponent<HingeJoint>().connectedBody = nextRB;
        cVans.GetComponent<Rigidbody>().centerOfMass = centreOfMass;

        Caravan c = cVans.GetComponent<Caravan>();
        nextSpawn = c.Spawn(gameObject);
        nextRB = c.GetRigidbody();
        caravanScripts.AddLast(c);

        NetworkServer.Spawn(cVans);
        caravanCount++;
        m_maxSpeed = 6000 * (caravanCount + 1);
        Debug.Log(m_maxSpeed);
    }


}
