using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (Input.GetKey(KeyCode.W)) { rb.AddForce(Vector3.forward); }
        if (Input.GetKey(KeyCode.S)) { rb.AddForce(Vector3.back); }

        if (Camera.main.GetComponent<Drunk>().drunk)
        {
            Debug.Log("DRUNK");
            if (Input.GetKey(KeyCode.A)) { rb.AddForce(Vector3.right); }
            if (Input.GetKey(KeyCode.D)) { rb.AddForce(Vector3.left); }
        }
        else
        {
            Debug.Log("SOBER");
            if (Input.GetKey(KeyCode.A)) { rb.AddForce(Vector3.left); }
            if (Input.GetKey(KeyCode.D)) { rb.AddForce(Vector3.right); }
        }

        
    }
}
