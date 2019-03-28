using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeExplosion : MonoBehaviour
{
    public Material material;
    public float    speed;
    private void OnDestroy()
    {
        for (int i = 0; i < 100; i++)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.localPosition = new Vector3(transform.localPosition.x + Random.Range(-1.0f,1.0f), 
                                                       transform.localPosition.y + Random.Range(-1.0f, 1.0f), 
                                                       transform.localPosition.z + Random.Range(-1.0f, 1.0f));
            cube.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            cube.GetComponent<Renderer>().material = material;
            cube.AddComponent<Rigidbody>().velocity = new Vector3(Random.Range(-1.0f, 1.0f) * speed, 
                                                                  Random.Range(-1.0f, 1.0f) * speed, 
                                                                  Random.Range(-1.0f, 1.0f) * speed);
        }
    }
}
