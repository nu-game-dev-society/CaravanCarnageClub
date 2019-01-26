using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caravan : MonoBehaviour
{

    [SerializeField] PlayerManager playerManager;
    [SerializeField] int index;

    public void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Destroyable" || collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
        {
            playerManager.DestroyCaravans(index);
            Debug.Log(index);
        }

    }

}
