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
    public float timeLeft = 20;
    public int score = 0;

	void Update ()
    {
        timeLeft -= Time.deltaTime;

        int timeLeftInt = (int)Mathf.Round(timeLeft);
        UIManager.Instance.UpdateTimer(timeLeftInt);
        if (timeLeft < 0)
            EndGame();
	}
    void EndGame()
    {
        print("LOSER");
    }
}
