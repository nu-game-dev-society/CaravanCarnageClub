using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScoreWebSubmit : MonoBehaviour {

    [SerializeField]
    InputField scoreSubmitName;

	public void SendScore()
    {
        if (scoreSubmitName.text != "")
        {
            ScoreWeb.Send(scoreSubmitName.text, (int)GameManager.Instance.score);
            EventSystem.current.currentSelectedGameObject.GetComponent<Button>().interactable = false;
        }
    }

    public void OpenScoreboard()
    {
        Application.OpenURL("http://81.174.149.122/ggj/");
    }
}
