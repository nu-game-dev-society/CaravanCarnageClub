using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof(Rigidbody))]
public class CarController : MonoBehaviour {

    [SerializeField] Rigidbody m_rigidbody;

    int currentSpeed;
    int maxSpeed;
    int acceleration;

    [SerializeField] Transform frontWheels;
    

	// Use this for initialization
	void Start ()
    {
        m_rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
       DirectionOfWheels();


 

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            Vector3 currentDir = frontWheels.eulerAngles;
            Vector3 dir = new Vector3(0, Input.GetAxisRaw("Horizontal"), 0);

          
            if (currentDir.y > 340 || currentDir.y < 20)
            {
                frontWheels.Rotate(dir);
                Quaternion wheelEulerAngles = frontWheels.localRotation;
                frontWheels.localRotation = wheelEulerAngles;
            }
            else if (currentDir.y <= 340 && dir.y > 0 && currentDir.y >40)
            {
                frontWheels.Rotate(dir);
                Quaternion wheelEulerAngles = frontWheels.localRotation;
                frontWheels.localRotation = wheelEulerAngles;
            }
            else if (currentDir.y >= 20 && dir.y < 0 && currentDir.y < 320)
            {
                frontWheels.Rotate(dir);
                Quaternion wheelEulerAngles = frontWheels.localRotation;
                frontWheels.localRotation = wheelEulerAngles;
            }

            


        }
    }




    Vector3 DirectionOfWheels()
    {
        Vector3 dir = new Vector3();

        Vector3 wheelDir1 = frontWheels.right;


        dir = wheelDir1;

        Debug.DrawRay(transform.position, dir * 10, Color.red);

        return dir;
    }

}
