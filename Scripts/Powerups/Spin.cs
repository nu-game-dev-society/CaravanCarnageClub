using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(transform.up * Time.deltaTime * 10.0f);
        transform.localPosition = transform.up + transform.up * (Mathf.Sin(Time.time) * 0.1f - 0.05f);
    }
}
