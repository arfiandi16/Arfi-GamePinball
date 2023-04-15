using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherController : MonoBehaviour
{
    public Collider bola;
    public KeyCode input;
    
    public Color pressedColor;
    public float maxTimeHold;
    public float maxForce;

    private bool isHold = false;
    private Color firstColor;
    private Material material;

    private void Start()
    {
        material = GetComponent<MeshRenderer>().material;
        firstColor = material.color;
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider == bola)
        {
            ReadInput(bola);
        }
    }

    private void ReadInput(Collider collider)
    {
        if (Input.GetKey(input) && !isHold)
        {
            StartCoroutine(StartHold(collider));
        }
    }

    private IEnumerator StartHold(Collider collider)
    {
        isHold = true;
        float force = 0.0f;
        float timeHold = 0.0f;
        while (Input.GetKey(input))
        {
            material.color = pressedColor;
            force = Mathf.Lerp(0,maxForce,timeHold/maxTimeHold);
            yield return new WaitForEndOfFrame();
            timeHold += Time.deltaTime;
        }
        collider.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
        isHold = false;
        material.color = firstColor;
    }
}
