using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caravan : MonoBehaviour {

    PlayerManager playerManager;
    HingeJoint myHinge;
    Rigidbody myRigidbody;


    public int index;

	// Use this for initialization
	void Start () {
        myRigidbody = gameObject.GetComponent<Rigidbody>();
        playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();
        playerManager.AddCaravan(this);
        myHinge = gameObject.GetComponent<HingeJoint>();
        index = playerManager.CountCaravans() - 1;
        myHinge.connectedBody = playerManager.myCaravans[index - 1].GetRigidbody();
        gameObject.name = "Caravan" + index;
	}

    public Rigidbody GetRigidbody()
    {
        return myRigidbody;
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
