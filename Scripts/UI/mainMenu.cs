using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {

    [SerializeField] GameObject credits;

    void Start()
    {
        Time.timeScale = 1;
    }

    public void OpenCredits()
    {
        credits.SetActive(true);
    }

    public void closeCredits()
    {
        credits.SetActive(false);
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
