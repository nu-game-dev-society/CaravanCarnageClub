using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {

    [SerializeField] GameObject main;
    [SerializeField] GameObject credits;
    [SerializeField] GameObject customize;
    [SerializeField] Transform customizeCamPos;

    [SerializeField]
    Camera mainCamera;

    Vector3 initCamPos = new Vector3();
    
    Vector3 endMarker = new Vector3();

    [SerializeField]
    float speed = 1.0f;

    void Start()
    {
        Time.timeScale = 1;

        initCamPos = mainCamera.transform.position;
        
        endMarker = initCamPos;
    }

    void Update()
    {
        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, endMarker, speed * Time.deltaTime);
    }

    public void OpenCredits()
    {
        credits.SetActive(true);
    }

    public void CloseCredits()
    {
        credits.SetActive(false);
    }

    public void OpenCustomize()
    {
        customize.SetActive(true);
        main.SetActive(false);
        
        endMarker = customizeCamPos.position;
    }

    public void CloseCustomize()
    {
        customize.SetActive(false);
        main.SetActive(true);
        
        endMarker = initCamPos;
    }

    public void ResetCustomize()
    {
        foreach (ColorPopup colPop in FindObjectsOfType<ColorPopup>())
        {
            colPop.reset();
        }
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
