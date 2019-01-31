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
    Color start;
    void Start()
    {
        start = timeClock.color;
    }
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
        //submitButton.interactable = true;
        OpenScoreboard();
    }


    public void PlayAgain()
    {
        SceneManager.LoadScene("main");
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("mainMenu");
    }
    public void FlashTimer(Color c)
    {
        timeClock.color = c;
        StartCoroutine(FlashColor());
    }
    IEnumerator FlashColor()
    {
        yield return new WaitForSeconds(0.6f);
        timeClock.color = start;
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
        if (scoreSubmitName.text != "" && scoreSubmitName.text.Length <= 10)
        {
            submitButton.interactable = false;
            ScoreWeb.Send(scoreSubmitName.text, (int)GameManager.Instance.score);
        }
        OpenScoreboard();
    }

    public void OpenScoreboard()
    {
        Score[] scores = ScoreWeb.Get();
        for (int i = 0; i < scoreFields.Length; i++)
        {
            if (i >= scores.Length)
                scoreFields[i].text = "";
            else
                scoreFields[i].text = scores[i].name + " : " + scores[i].score;        
        }
    }
    #endregion
}
