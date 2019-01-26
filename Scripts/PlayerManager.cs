﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    [SerializeField] GameObject[] Caravans;
    public int caravansCollected;

    public void Start()
    {
        
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            activateCaravan();
        }
    }

    public void activateCaravan()
    {
        if (caravansCollected < Caravans.Length - 1)
        {
            Caravans[caravansCollected].GetComponent<MeshRenderer>().enabled = true;
            Caravans[caravansCollected].GetComponent<Collider>().enabled = true;
            caravansCollected += 1;
        }
    }

    public void DestroyCaravans(int startIndex)
    {
        for (int i = startIndex; i < Caravans.Length; i++)
        {

            Caravans[i].GetComponent<MeshRenderer>().enabled = false;
            Caravans[i].GetComponent<Collider>().enabled = false;
            caravansCollected -= 1;
            //TODO INSTANTIATE EXPLOSION AT POSITION!
        }
    }





}
