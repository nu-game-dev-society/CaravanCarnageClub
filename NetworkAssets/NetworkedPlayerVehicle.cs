using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkedPlayerVehicle : MonoBehaviourPun, IPunObservable
{

    Vector3 targetPos;
    Quaternion targetRot;

    void Awake()
    {
        if(!photonView.IsMine)
            Destroy(GetComponent<Vehicle>());
    }
    void Update()
    {
        if(!photonView.IsMine)
        {
            float interp = 10f * Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, targetPos, interp);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, interp);
        }
    }
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)//is sending
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else
        {
            targetPos = (Vector3)stream.ReceiveNext();
            targetRot = (Quaternion)stream.ReceiveNext();
        }
    }
}
