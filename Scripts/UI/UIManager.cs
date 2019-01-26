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
    [SerializeField]
    Text score;
    [SerializeField]bool paused;

    [SerializeField] GameObject endScreen;
    [SerializeField] GameObject PauseScreen;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
                PauseGame();
            else
                UnpauseGame();
        }
    }

    public void UpdateTimer(float time)
    {
        int intTime = (int)Mathf.Round(time);
        timer.text = intTime.ToString();
        timeClock.fillAmount = time / 60;
    }
    public void UpdateScore(int score)
    {
        string scoreS = score.ToString().PadLeft(8, '0');

        this.score.text = scoreS;
        
    }
    void PauseGame()
    {
        PauseScreen.SetActive(true);
        Time.timeScale = 0;
        paused = true;
    }

    void UnpauseGame()
    {
        Time.timeScale = 1;
        PauseScreen.SetActive(false);
        paused = false;
    }

    public void EndScreen()
    {
        endScreen.SetActive(true);
    }


    public void PlayAgain()
    {
        SceneManager.LoadScene("main");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
