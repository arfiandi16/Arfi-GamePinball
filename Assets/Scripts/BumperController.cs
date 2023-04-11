using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    private Renderer renderer;
    private Animator animator;

    public Collider colliderBola;
    public float multiplier;
    Rigidbody bolaRig;
    public Color color;

    private void Start()
    {
        animator = GetComponent<Animator>();
        renderer = GetComponent<Renderer>();
        renderer.material.color = color;
        bolaRig = colliderBola.GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider == colliderBola)
        {
            bolaRig.velocity *= multiplier;

            if (animator != null)
            {
                animator.SetTrigger("hit");
            }
            
        }
    }
}