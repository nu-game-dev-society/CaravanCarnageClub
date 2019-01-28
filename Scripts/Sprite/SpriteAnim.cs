using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnim : MonoBehaviour
{
    [SerializeField]
    float frameTime = 0.5f;

    float nextFrameTime = 0.0f;

    [SerializeField]
    Sprite[] images;

    int currentFrame = 0;

    SpriteRenderer spr;

	// Use this for initialization
	void Start () {
        spr = GetComponent<SpriteRenderer>();
        spr.sprite = images[currentFrame];
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextFrameTime)
        {
            nextFrameTime += frameTime;

            spr.sprite = images[currentFrame];

            currentFrame++;
            if (currentFrame >= images.Length)
            {
                currentFrame = 0;
            }
        }
	}
}
