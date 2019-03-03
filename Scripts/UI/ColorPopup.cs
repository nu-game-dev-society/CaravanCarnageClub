using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPopup : MonoBehaviour {

    [SerializeField]
    GameObject colorPicker;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(Toggle);
    }

    private void Toggle()
    {
        colorPicker.SetActive(!colorPicker.active);
        colorPicker.transform.position = Input.mousePosition;
    }
}
