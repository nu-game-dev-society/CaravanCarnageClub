using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof(Rigidbody))]
public class CarController : MonoBehaviour {

    [SerializeField] Rigidbody m_rigidbody;


    public float m_acceleration;
    public float m_currentSpeed;
    public float m_maxSpeed;
    public float m_TurnSpeed;


    Rigidbody m_Rigidbody;
    Transform m_Transform;

    AudioSource m_AudioSource;

    [SerializeField] AudioClip accel, idle, deaccel, skid;
   

    // Use this for initialization
    void Start ()
    {
        m_TurnSpeed = 0;
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Transform = GetComponent<Transform>();
        m_AudioSource = GetComponent<AudioSource>();
        m_AudioSource.clip = idle;
        m_AudioSource.Play();
       
    

        m_Rigidbody.centerOfMass = new Vector3(m_Rigidbody.centerOfMass.x, m_Rigidbody.centerOfMass.y - 1, m_Rigidbody.centerOfMass.z);
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

        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        if (IsGrounded())
        {
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


       
        

        if(m_currentSpeed > 1000 && v > 0)
            m_AudioSource.clip = accel;


        if (m_currentSpeed > 1000 && v < 0)
            m_AudioSource.clip = deaccel;


        if (!m_AudioSource.isPlaying)
            m_AudioSource.Play();


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
