using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (Input.GetKey(KeyCode.W)){rb.AddForce(Vector3.forward);}
        if (Input.GetKey(KeyCode.S)){rb.AddForce(Vector3.back);}
        if (Input.GetKey(KeyCode.A)){rb.AddForce(Vector3.left);}
        if (Input.GetKey(KeyCode.D)){rb.AddForce(Vector3.right);}
    }
}
