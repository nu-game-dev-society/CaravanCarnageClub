using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object3DSpin : MonoBehaviour {
    //public float bounceSpeed = 2.0f; - REDACTED
    public float spinSpeed   = 100.0f;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up, spinSpeed);
        //transform.position =  new Vector3 (transform.position.x, Mathf.PingPong(Time.time * bounceSpeed, 5.0f), transform.position.z); - REDACTED
    }
}