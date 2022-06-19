using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Quaternion camRot;
    Vector3 offsetFromPlayer;
    Transform player;
    private void Start()
    {
        camRot = transform.rotation;
        player = transform.parent;
        offsetFromPlayer = transform.position - player.position;
    }
    void LateUpdate()
    {
        transform.rotation = camRot;
        transform.position = player.position + offsetFromPlayer;
    }
}
