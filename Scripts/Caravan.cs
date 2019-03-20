using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caravan : MonoBehaviour
{
    [SerializeField] Transform nextSpawn;
    [SerializeField] PlayerManager playerManager;
    [SerializeField] int index;

    public Transform Spawn(GameObject player)
    {
        playerManager = player.GetComponent<PlayerManager>();
        return nextSpawn;
    }
    public Rigidbody GetRigidbody()
    {
        return GetComponent<Rigidbody>();
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
