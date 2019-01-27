using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drunk : MonoBehaviour {

    public Material material;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.05f;

    //Pulsate FOV Clamp (+/-)
    public const float FOV_DELTA = 5f;

    //Backup
    Vector3 originalPos;
    float originalFov;

    public bool drunk = false;
    float drunkTime = 0;
    UnityStandardAssets.Vehicles.Car.CarUserControl carControl;

    void Awake()
    {
        originalFov = Camera.main.fieldOfView;
    }
    private void Start()
    {
        carControl = GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets.Vehicles.Car.CarUserControl>();
    }

    void OnEnable()
    {
        originalPos = transform.localPosition;
    }

    void Update()
    {
        drunkTime -= Time.deltaTime;
        if (drunkTime < 0)
        {
            drunk = false;
            carControl.inverse = 1;
        }

        /*if (drunk)
        {
            transform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            //Pulsate
            //Camera.main.fieldOfView = Mathf.PingPong(originalFov + (Time.time*10), originalFov + FOV_DELTA);
            Camera.main.fieldOfView = Mathf.Lerp(originalFov - FOV_DELTA, originalFov + FOV_DELTA, Mathf.PingPong(Time.time * 0.4f, 1));
        }
        else
        {
            transform.localPosition = originalPos;
        }*/
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (drunk)
        {
            Graphics.Blit(source, destination, material);
        }
        else
        {
            Graphics.Blit(source, destination);
        }
    }

    public void AddDrunkTime(int time)
    {
        if (drunkTime < 0)
        {
            drunkTime = time;
        }
        else
        {
            drunkTime += time;
        }
        carControl.inverse = -1;
    }
}
