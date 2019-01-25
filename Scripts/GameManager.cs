using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Me;

    public int timeLeft = 500;
    public int score = 0;

    [SerializeField]
    float timeLeftRaw = 500;

    private static GameManager s_Instance = null;

    public static GameManager instance
    {
        get
        {
            if (s_Instance == null)
            {
                // FindObjectOfType() returns the first AManager object in the scene.
                s_Instance = FindObjectOfType(typeof(GameManager)) as GameManager;
            }

            // If it is still null, create a new instance
            if (s_Instance == null)
            {
                var obj = new GameObject("GameManager");
                s_Instance = obj.AddComponent<GameManager>();
            }

            return s_Instance;
        }
    }

    void OnApplicationQuit()
    {
        s_Instance = null;
    }
	
	void Update ()
    {
        timeLeftRaw -= Time.deltaTime;

        timeLeft = (int)Mathf.Round(timeLeftRaw);

        if (timeLeft < 0) { timeLeft = 0; }
	}
}
