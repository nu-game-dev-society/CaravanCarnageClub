using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelSpawner : MonoBehaviour {

    [SerializeField]
    Vector3 minArea;

    [SerializeField]
    Vector3 maxArea;

    [SerializeField]
    int maxBarrels = 10;
    int barrelCount = 0;

    [SerializeField]
    GameObject barrel;

    float nextActionTime = 0.0f;

    [SerializeField]
    float period = 10;


	// Use this for initialization
	void Start () {
        SpawnBarrels();
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;

            barrelCount = transform.childCount;
            
            if (barrelCount < maxBarrels)
            {
                SpawnBarrels();
            }
        }
	}

    void SpawnBarrels()
    {
        while (barrelCount < maxBarrels)
        {
            Vector3 pos = new Vector3(Random.Range(minArea.x, maxArea.x), Random.Range(minArea.y, maxArea.y), Random.Range(minArea.z, maxArea.z));

            RaycastHit hit;
            if (Physics.BoxCast(pos, barrel.transform.localScale, Vector3.down, out hit, Quaternion.identity, Mathf.Infinity))
            {
                if (hit.transform.tag == "Terrain")
                {
                    GameObject tmpBarrel = GameObject.Instantiate(barrel);
                    tmpBarrel.transform.SetParent(transform);
                    tmpBarrel.transform.position = hit.point;

                    barrelCount++;
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;

        Vector3 tmpVec = minArea;
        tmpVec.z = maxArea.z;
        Gizmos.DrawLine(minArea, tmpVec);

        tmpVec = minArea;
        tmpVec.y = maxArea.y;
        Gizmos.DrawLine(minArea, tmpVec);

        tmpVec = minArea;
        tmpVec.x = maxArea.x;
        Gizmos.DrawLine(minArea, tmpVec);


        tmpVec = maxArea;
        tmpVec.z = minArea.z;
        Gizmos.DrawLine(maxArea, tmpVec);

        tmpVec = maxArea;
        tmpVec.y = minArea.y;
        Gizmos.DrawLine(maxArea, tmpVec);

        tmpVec = maxArea;
        tmpVec.x = minArea.x;
        Gizmos.DrawLine(maxArea, tmpVec);
    }
}
