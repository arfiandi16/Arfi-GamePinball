using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public GameObject vfxBumperSource;
    public GameObject vfxSwitchSource;
    public void PlayVFXBumper(Vector3 spamPosition)
    {
        GameObject.Instantiate(vfxBumperSource, spamPosition, Quaternion.identity);
    }

    public void PlayVFXSwitch(Vector3 spamPosition)
    {
        GameObject.Instantiate(vfxSwitchSource, spamPosition, Quaternion.identity);
    }
}
