using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosions : MonoBehaviour {

    public AudioSource audio;
    

	// Use this for initialization
	void Start () {
        audio.Play();
        StartCoroutine(Decay());
	}

    IEnumerator Decay()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}

