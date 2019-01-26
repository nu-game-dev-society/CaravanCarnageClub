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
    [SerializeField]
    Image timeClock;

    [SerializeField] GameObject endScreen;

    public void UpdateTimer(float time)
    {
        int intTime = (int)Mathf.Round(time);
        timer.text = intTime.ToString();
        timeClock.fillAmount = time / 60;
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
