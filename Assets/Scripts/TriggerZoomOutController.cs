using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoomOutController : MonoBehaviour
{
    public Collider bola;
    public CameraController cameraC; 

    private void OnTriggerEnter(Collider other)
    {
        if (other == bola)
        {
            cameraC.GoBackToDefault();
        }
    }
}
