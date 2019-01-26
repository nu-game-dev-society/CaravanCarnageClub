using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    [SerializeField] GameObject endScreen;

    public void UpdateTimer(int time)
    {
        timer.text = time.ToString() + " SECONDS";
    }

    public void EndScreen()
    {
        endScreen.SetActive(true);
    }


    public void PlayAgain()
    {
        SceneManager.LoadScene("main");
    }
}
