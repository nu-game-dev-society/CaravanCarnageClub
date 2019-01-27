using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

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
        OpenScoreboard();
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
        submitButton.interactable = true;
        OpenScoreboard();
    }


    public void PlayAgain()
    {
        SceneManager.LoadScene("main");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    #region score
    [SerializeField]
    Text[] scoreFields;
    [SerializeField]
    InputField scoreSubmitName;
    [SerializeField]
    Button submitButton;
    public void SendScore()
    {
        if (scoreSubmitName.text != "")
        {
            ScoreWeb.Send(scoreSubmitName.text, (int)GameManager.Instance.score);
            OpenScoreboard();
            submitButton.interactable = false;
        }
    }

    public void OpenScoreboard()
    {
        //Application.OpenURL("http://81.174.149.122/ggj/");
        Score[] scores = ScoreWeb.Get();
        for (int i = 0; i < scoreFields.Length; i++)
            scoreFields[i].text = scores[i].name + " : " + scores[i].score;
    }
    #endregion
}
