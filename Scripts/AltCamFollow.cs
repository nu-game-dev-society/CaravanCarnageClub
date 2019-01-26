using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltCamFollow : MonoBehaviour {

    public Transform player;
    public float distz;
    public float disty;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 temp = transform.position;
        temp.z = player.position.z - distz;
        temp.x = player.position.x - disty;

        transform.position = temp;

    }
}
