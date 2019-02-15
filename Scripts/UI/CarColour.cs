using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarColour : MonoBehaviour {

    [SerializeField]
    private Texture carTex;

    [SerializeField]
    private Material carMat;
    
    private Material newCarMat;

    [SerializeField]
    private MeshRenderer car;

    [SerializeField]
    private CUIColorPicker colPic;

    // Use this for initialization
    void Start ()
    {
        //newCarMat = carMat;
        newCarMat = new Material(carMat);
        Material[] mats = car.materials;
        mats[2] = newCarMat;
        car.materials = mats;
    }
	
	// Update is called once per frame
	void Update ()
    {
        newCarMat.color = colPic.Color;
	}
}
