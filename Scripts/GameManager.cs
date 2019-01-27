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
    public float score = 0;

    [SerializeField]
    PlayerManager pM;
    private void Start()
    {
        Time.timeScale = 1;
    }
    int lastCaravan = 0;
    void Update ()
    {
        if(timeLeft > 0)
            timeLeft -= Time.deltaTime;
        UIManager.Instance.UpdateTimer(timeLeft);
        if (lastCaravan != pM.caravansCollected)
        {
            lastCaravan = pM.caravansCollected;
        }
        score += Time.deltaTime*20+ (Time.deltaTime * pM.caravansCollected * 3f);
        UIManager.Instance.UpdateScore((int)Mathf.RoundToInt(score));
        if (timeLeft < 0)
            EndGame();
	}
    void EndGame()
    {
        Time.timeScale = 0;
        UIManager.Instance.EndScreen();
    }

    

}
