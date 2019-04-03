using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    #region Singleton Pattern
    public static ObjectManager Instance { get; private set; }
    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    #endregion

    [Header("Object")]
    public int maxInstances = 10;
    public GameObject obj;

    [Header("Position Constraints")]
    public Vector3 minVal = Vector3.zero;
    public Vector3 maxVal = Vector3.zero;

    /**/
    private List<GameObject> gameObjects;

    private void Start()
    {
        for (int i = 0; i < maxInstances; i++)
        {
            GameObject newGO = Instantiate(obj, Vector3.zero, Quaternion.identity);

            newGO.transform.localPosition = new Vector3(Random.Range(minVal.x, maxVal.x), Random.Range(minVal.y, maxVal.y), Random.Range(minVal.z, maxVal.z));

            gameObjects.Add(newGO);
            print(i);
        }
    }

    void Update()
    {
        
    }    
}