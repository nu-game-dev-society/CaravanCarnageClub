using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caravan : MonoBehaviour {

    PlayerManager playerManager;

    public int index;

	// Use this for initialization
	void Start () {
        playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();
        playerManager.AddCaravan(this);
        index = playerManager.CountCaravans() - 1;
        gameObject.name = "Caravan" + index;
	}
	
	//Destroys this caravan @todo Make it explode and shit
	public void DestroyCaravan ()
    {
        Destroy(gameObject);
	}

    
    public void OnCollisionEnter(Collision collision)
    {
        //If it collides with something that should blow it the fuck up 
        if (collision.gameObject.CompareTag("Something"))
        {
            playerManager.DestroyCaravan(index);
        }
    }
}
