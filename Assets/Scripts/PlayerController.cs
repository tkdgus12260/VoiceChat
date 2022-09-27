using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    private float hAxis;
    private float vAxis;
    private float speed = 10.0f;
    private Vector3 moveVec;

    private PhotonView pv;
    private CinemachineVirtualCamera virCamera;

    private void Start()
    {
        pv = GetComponent<PhotonView>();
        virCamera = GameObject.FindObjectOfType<CinemachineVirtualCamera>();

        if (pv.IsMine)
        {
            virCamera.Follow = transform;
            virCamera.LookAt = transform;
        }
    }

    private void Update()
    {
        if(pv.IsMine)
            Move();
    }

    private void Move()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");

        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += moveVec * speed * Time.deltaTime;
    }

}
