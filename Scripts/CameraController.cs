using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField]
    Transform target;
    [SerializeField]
    float maxDist;

	void LateUpdate () {
        Vector3 camPos = transform.position;
        Vector3 carPos = target.position;
        float dist = Vector3.Distance(camPos, carPos);
        if (dist > maxDist)
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(carPos.x, camPos.y, carPos.z), 5*Time.deltaTime);
        transform.LookAt(carPos);
	}
}
