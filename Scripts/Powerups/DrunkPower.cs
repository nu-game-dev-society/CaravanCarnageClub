using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrunkPower : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        Camera.main.GetComponent<Drunk>().drunk = true;
        Camera.main.GetComponent<Drunk>().AddDrunkTime(5);
        Destroy(gameObject);
    }
}
