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

    [SerializeField]
    Button toggleButton;

    [SerializeField]
    Button backgroundButton;

    private Transform recent;

    private Color getColFromPrefStr(string colour)
    {
        string[] colParts = colour.Replace("RGBA(", "").Replace(")", "").Split(',');

        if (colParts.Length < 4)
        {
            return Color.white;
        }

        return new Color(float.Parse(colParts[0]), float.Parse(colParts[1]), float.Parse(colParts[2]), float.Parse(colParts[3]));
    }

    private Color[] GetColPref()
    {
        List<Color> colours = new List<Color>();

        string prefStr = PlayerPrefs.GetString(prefField + "Recent", "");

        if (prefStr != "")
        {
            string[] recentColours = prefStr.Split(';');
            foreach (string colour in recentColours)
            {
                colours.Add(getColFromPrefStr(colour));
            }
        }        

        return colours.ToArray();
    }

    private void AddColPref(Color addCol)
    {
        List<Color> preCols = GetColPref().OfType<Color>().ToList();
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

        PlayerPrefs.SetString(prefField + "Recent", newColsStr.Trim(';'));
    }

    private void Start()
    {
        toggleButton.onClick.AddListener(Toggle);
        backgroundButton.onClick.AddListener(Hide);
        recent = colorPicker.transform.Find("CUIColorPicker/Recent");

        if (PlayerPrefs.GetString(prefField + "Current", "") == "")
        {
            reset();
        }

        colorPicker.GetComponentInChildren<CUIColorPicker>().Color = getColFromPrefStr(PlayerPrefs.GetString(prefField + "Current", ""));
    }

    public void reset()
    {
        Color defCol = Color.white;

        if (prefField == "CarBody")
        {
            defCol = new Color((float)14 / 255, (float)63 / 255, (float)16 / 255);
        }
        else if (prefField == "CarHood")
        {
            defCol = new Color((float)0 / 255, (float)0 / 255, (float)0 / 255);
        }

        PlayerPrefs.SetString(prefField + "Current", defCol.ToString());
        AddColPref(defCol);
        colorPicker.GetComponentInChildren<CUIColorPicker>().Color = defCol;
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
                if (!(colPop == this))
                {
                    colPop.Hide();
                }
            }
        }
        
        colorPicker.SetActive(!colorPicker.activeSelf);
        colorPicker.transform.position = Input.mousePosition;
        colorPicker.transform.SetAsLastSibling();

        if (!colorPicker.activeSelf)
        {
            AddColPref(colorPicker.GetComponentInChildren<CUIColorPicker>().Color);

            PlayerPrefs.SetString(prefField + "Current", colorPicker.GetComponentInChildren<CUIColorPicker>().Color.ToString());

            foreach (Transform trans in recent)
            {
                Destroy(trans.gameObject);
            }
        }
        else
        {
            colorPicker.GetComponentInChildren<CUIColorPicker>().Color = getColFromPrefStr(PlayerPrefs.GetString(prefField + "Current", ""));

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
        if (colorPicker.activeSelf)
        {
            ToggleRaw(false);
        }
    }
}
