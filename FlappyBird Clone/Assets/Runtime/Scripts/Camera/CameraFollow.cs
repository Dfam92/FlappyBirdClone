using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteAlways]
public class CameraFollow : MonoBehaviour
{
    [SerializeField] private PlayerControl player;
    [SerializeField] private float distanceCameraZ;

    private void LateUpdate()
    {
        Vector3 currentPos = transform.position;
        Vector3 playerPos = player.transform.position;
        currentPos = playerPos;
        currentPos.z = playerPos.z + distanceCameraZ;
        this.transform.position = currentPos;
    }
   
}
