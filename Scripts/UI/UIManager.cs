using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Singleton Pattern
    public static UIManager Instance { get; private set; }


    void Awake()
    {
        if(Instance == null)
            Instance = this;
    }
#endregion
    [SerializeField]
    Text timer;
    public void UpdateTimer(int time)
    {
        timer.text = time.ToString();
    }
}
