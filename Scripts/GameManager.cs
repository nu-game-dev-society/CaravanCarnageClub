using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    #region Singleton Pattern
    public static GameManager Instance { get; private set; }
    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    #endregion
    public float timeLeft = 2;
    public int score = 0;

    [SerializeField] UIManager uiManager;

    private void Start()
    {
        Time.timeScale = 1;
    }

    void Update ()
    {
        if(timeLeft > 0)
            timeLeft -= Time.deltaTime;

        int timeLeftInt = (int)Mathf.Round(timeLeft);
        UIManager.Instance.UpdateTimer(timeLeftInt);
        if (timeLeft < 0)
            EndGame();
	}
    void EndGame()
    {
        Time.timeScale = 0;
        uiManager.EndScreen();
        print("LOSER");
    }
}
