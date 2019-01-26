using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caravan : MonoBehaviour {

    PlayerManager playerManager;
    GameObject player;
    HingeJoint myHinge;
    Rigidbody myRigidbody;

    public Transform nextSpawn;


    public int index;

	// Use this for initialization
	void Start () {
        myRigidbody = gameObject.GetComponent<Rigidbody>();
        playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();
        //player = GameObject.FindGameObjectWithTag("Player");
        playerManager.AddCaravan(this);
        myHinge = gameObject.GetComponent<HingeJoint>();
        index = playerManager.CountCaravans() - 1;
        gameObject.name = "Caravan" + index;
        SetUpHinge();
	}

    public Rigidbody GetRigidbody()
    {
        return myRigidbody;
    }

    void SetUpHinge()
    {

        if (index > 0)
        {
            transform.position = playerManager.myCaravans[index - 1].nextSpawn.position;
            transform.rotation = playerManager.myCaravans[index - 1].nextSpawn.rotation;
            myHinge.connectedBody = playerManager.myCaravans[index - 1].GetRigidbody();
        }
        else
        {
            transform.position = playerManager.firstSpawn.position;
            transform.rotation = playerManager.firstSpawn.rotation;
            myHinge.connectedBody = playerManager.gameObject.GetComponent<Rigidbody>();
        }
    }
	
	//Destroys this caravan @todo Make it explode and shit
	public void DestroyCaravan ()
    {
        Destroy(gameObject);
	}

    
    /*public void OnCollisionEnter(Collision collision)
    {
        //If it collides with something that should blow it the fuck up 
        if (collision.gameObject.CompareTag("Something"))
        {
            playerManager.DestroyCaravan(index);
        }
    }*/
}
