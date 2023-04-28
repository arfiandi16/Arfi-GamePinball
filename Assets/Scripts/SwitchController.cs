using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{ 

    private enum SwitchState
    {
        Off,
        On,
        Blink
    }
    public Collider bola;
    public Material offMaterial,onMaterial;
    public AudioManager audioManager;
    public VFXManager vfxManager;
    public ScoreManager scoreManager;
    public float score;

    private SwitchState state;
    private Renderer renderer; 
    void Start()
    { 
        renderer = GetComponent<Renderer>();
        Set(false);
        StartCoroutine(BlinkTimerStart(5));
    } 

    private void OnTriggerEnter(Collider other) 
    {
        if(other == bola)
        {
            Toggle();
            //Script dibawah dipakai apabila Bola akan mengeluarkan suara jika mengenai switch namun hanya dengan satu sfx, untuk yang dua sfx saya berikan didalam
            //fungsi toggle()
            //audioManager.PlaySFXSwitch(other.transform.position);
            vfxManager.PlayVFXSwitch(other.transform.position);
            scoreManager.AddScore(score);
        }
    }

    private void Set(bool active)
    { 
        if(active == true)
        {
            state = SwitchState.On;
            renderer.material = onMaterial;
            StopAllCoroutines();
            
        }
        else
        {
            state = SwitchState.Off;
            renderer.material = offMaterial;
            StartCoroutine(BlinkTimerStart(5));
            
        }
    }


    private void Toggle()
    {
        if( state == SwitchState.On)
        {
            //Saat bola menyalakan switch maka akan berbunyi
            audioManager.PlaySFXSwitchEND(bola.transform.position);
            Set(false); 
        }
        else
        {
            //Saat bola mematikan switch maka akan berbunyi
            audioManager.PlaySFXSwitch(bola.transform.position);
            Set(true); 
        }
    }
    private IEnumerator Blink(int times)
    {
        state = SwitchState.Blink; 
        for (int i = 0; i < times; i++)
        {
            renderer.material = onMaterial;
            yield return new WaitForSeconds(0.5f); 
            renderer.material = offMaterial;
            yield return new WaitForSeconds(0.5f); 
        } 
        state = SwitchState.Off;
        StartCoroutine(BlinkTimerStart(5));
    }

    private IEnumerator BlinkTimerStart(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Blink(2));
    }
}
