using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarColour : MonoBehaviour {

    [SerializeField]
    private Texture carTex;

    [SerializeField]
    private Material carBodyMat;

    [SerializeField]
    private MeshRenderer car;

    [SerializeField]
    private CUIColorPicker colBodyPic;

    [SerializeField]
    private Material carHoodMat;

    [SerializeField]
    private CUIColorPicker colHoodPic;

    private Material newCarBodyMat;
    private Material newCarHoodMat;

    // Use this for initialization
    void Start ()
    {
        newCarBodyMat = new Material(carBodyMat);
        newCarHoodMat = new Material(carHoodMat);

        Material[] mats = car.materials;
        mats[2] = newCarBodyMat;
        mats[3] = newCarHoodMat;
        car.materials = mats;
    }
	
	// Update is called once per frame
	void Update ()
    {
        newCarBodyMat.color = colBodyPic.Color;
        newCarHoodMat.color = colHoodPic.Color;
    }
}
