using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoomInController : MonoBehaviour
{
    public Collider bola;
    public CameraController cameraC;
    public float length;

    private void OnTriggerEnter(Collider other)
    {
        if(other == bola)
        {
            cameraC.FollowAtTarget(bola.transform, length);
        }
    }
}
