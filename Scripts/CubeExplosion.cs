using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeExplosion : MonoBehaviour
{
    public  Material material;
    public  float    speed;
    
    static private List<GameObject> cubes;

    private int iFrame = 0;
    private float spacing = 1.0f;
    private Vector3 parentPosition;

    private void Start()
    {
        parentPosition = gameObject.transform.position;
        cubes = new List<GameObject>();        

        for (int i = 0; i < 100; i++)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            cube.GetComponent<Renderer>().material = material;
            cube.AddComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
            cube.transform.localPosition = parentPosition + new Vector3(Random.Range(-spacing, spacing), 
                                                                        Random.Range(-spacing, spacing), 
                                                                        Random.Range(-spacing, spacing));
            cubes.Add(cube);
        }
    }

    private void Update()
    {
        //TEMP: Explode on iFrame #300, reset on iFrame #450
        if (iFrame == 300) Explode();
        if (iFrame == 450) ResetCubes();
        iFrame++;
    }

    private void ResetCubes()
    {
        foreach (GameObject cube in cubes)
        {
            cube.transform.localPosition = parentPosition + new Vector3(Random.Range(-spacing, spacing),
                                                                        Random.Range(-spacing, spacing),
                                                                        Random.Range(-spacing, spacing));

            cube.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        iFrame = 0;
    }

    private void Explode()
    {
        ResetCubes(); //Reset for safety before explosion
        foreach(GameObject cube in cubes)
        {   
            cube.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-1.0f, 1.0f) * speed, 
                                                                  Random.Range(-1.0f, 1.0f) * speed, 
                                                                  Random.Range(-1.0f, 1.0f) * speed);            
        }
    }
}
