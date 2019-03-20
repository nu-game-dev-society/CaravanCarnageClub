using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosions : MonoBehaviour {

    public AudioSource audioSource;
    

	// Use this for initialization
	void Start () {
        audioSource.Play();
        StartCoroutine(Decay());
	}

    IEnumerator Decay()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}

