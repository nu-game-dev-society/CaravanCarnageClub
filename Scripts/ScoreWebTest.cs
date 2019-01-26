using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreWebTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        ScoreWeb.Send("David", 892);

        foreach (Score sco in ScoreWeb.Get())
        {
            Debug.Log(sco.score + " - " + sco.name);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
