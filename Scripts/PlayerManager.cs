using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public List<Caravan> myCaravans = new List<Caravan>();

    public GameObject caravan;

    public Transform firstSpawn;


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
            CaravanCreationTest();
    }


    public void CaravanCreationTest()
    {
        GameObject newCaravan = Instantiate(caravan);
        //newCaravan.transform.SetParent(transform);
    }

    //Adds a new caravan
    public void AddCaravan(Caravan caravan)
    {
        myCaravans.Add(caravan);
    }

    public int CountCaravans()
    {
        return myCaravans.Count;
    }

    public void DestroyCaravan(int caravanIndex)
    {
        for (int i = caravanIndex; i < myCaravans.Count; i++)
        {
            myCaravans[i].DestroyCaravan();
        }
    }
}
