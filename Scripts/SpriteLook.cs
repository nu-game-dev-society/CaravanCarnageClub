using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLook : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 targetPostition = Camera.main.transform.position;
        targetPostition.x = transform.position.x;
        transform.LookAt(targetPostition);
	}
}
