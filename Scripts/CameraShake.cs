using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    public Transform camTransform;

    // How long the object should shake for.
    public float shakeDuration = 0f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 0.0f;

    //Pulsate FOV Clamp (+/-)
    public const float FOV_DELTA = 5f;

    //Backup
    Vector3 originalPos;
    float originalFov;

    bool drunk = true;

    

    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
        originalFov = Camera.main.fieldOfView;
    }

    void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }

    void Update()
    {
        if (drunk)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;

            //Pulsate
            //Camera.main.fieldOfView = Mathf.PingPong(originalFov + (Time.time*10), originalFov + FOV_DELTA);
            Camera.main.fieldOfView = Mathf.Lerp(originalFov - FOV_DELTA, originalFov + FOV_DELTA, Mathf.PingPong(Time.time * 0.4f, 1));
        }
        else
        {
            shakeDuration = 0f;
            camTransform.localPosition = originalPos;
        }
    }
}
