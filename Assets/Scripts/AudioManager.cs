using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource bgmSource;
    public GameObject sfxSource;
    public GameObject sfxSwitchSource;
    public GameObject sfxSwitchSourceEND;

    void Start()
    {
        PlayBGM();   
    }

    private void PlayBGM()
    {
        bgmSource.Play();
    }

    public void PlaySFXBumper(Vector3 spamPosition)
    {
        GameObject.Instantiate(sfxSource,spamPosition,Quaternion.identity);
    }

    public void PlaySFXSwitch(Vector3 spamPosition)
    {
        GameObject.Instantiate(sfxSwitchSource, spamPosition, Quaternion.identity);
    }
    public void PlaySFXSwitchEND(Vector3 spamPosition)
    {
        GameObject.Instantiate(sfxSwitchSourceEND, spamPosition, Quaternion.identity);
    }
}
