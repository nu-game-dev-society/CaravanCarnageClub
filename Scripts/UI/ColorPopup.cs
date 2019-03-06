using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ColorPopup : MonoBehaviour {

    [SerializeField]
    GameObject colorPicker;

    [SerializeField]
    GameObject recentColorPrefab;

    [SerializeField]
    string prefField;

    private Transform recent;

    private Color[] GetColPref()
    {
        List<Color> colours = new List<Color>();

        string prefStr = PlayerPrefs.GetString(prefField, "");

        if (prefStr != "")
        {
            string[] recentColours = prefStr.Split(';');
            foreach (string colour in recentColours)
            {
                string[] colParts = colour.Replace("RGBA(", "").Replace(")", "").Split(',');

                Color col = new Color(float.Parse(colParts[0]), float.Parse(colParts[1]), float.Parse(colParts[2]), float.Parse(colParts[3]));
                colours.Add(col);
            }
        }        

        return colours.ToArray();
    }

    private void AddColPref(Color addCol)
    {
        List<Color> preCols = GetColPref().OfType<Color>().ToList(); ;
        preCols.Insert(0, addCol);

        Color[] newCols = preCols.ToArray();

        string newColsStr = "";
        for (int i = 0; i < 12; i++)
        {
            if (i < newCols.Length)
            {
                newColsStr += newCols[i].ToString() + ";";
            }
        }

        PlayerPrefs.SetString(prefField, newColsStr.Trim(';'));

    }

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(Toggle);
        recent = colorPicker.transform.Find("CUIColorPicker/Recent");
    }

    private void Toggle()
    {
        ToggleRaw(true);
    }

    private void ToggleRaw(bool check)
    {
        if (check)
        {
            foreach (ColorPopup colPop in FindObjectsOfType<ColorPopup>())
            {
                colPop.Hide();
            }
        }        

        colorPicker.SetActive(!colorPicker.active);
        colorPicker.transform.position = Input.mousePosition;
        colorPicker.transform.SetAsLastSibling();

        if (!colorPicker.active)
        {
            AddColPref(colorPicker.GetComponentInChildren<CUIColorPicker>().Color);

            foreach (Transform trans in recent)
            {
                Destroy(trans.gameObject);
            }
        }
        else
        {
            Color[] recentCols = GetColPref();
            
            foreach (Color col in recentCols)
            {
                GameObject recentCol = GameObject.Instantiate(recentColorPrefab);
                recentCol.transform.SetParent(recent.transform);
                recentCol.GetComponent<Image>().color = col;
            }
        }
    }

    public void Hide()
    {
        if (colorPicker.active)
        {
            ToggleRaw(false);
        }
    }
}
