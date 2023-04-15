using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Vector3 firstPosition;
    private Rigidbody rigidBody;
    public float maxSpeed; 
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        firstPosition = transform.position;
    }

    private void Update()
    {
        if(rigidBody.velocity.magnitude > maxSpeed)
        {
            rigidBody.velocity = rigidBody.velocity.normalized * maxSpeed;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("deadzone"))
        {
            StartCoroutine(BallReset());
        }
    } 
    IEnumerator BallReset()
    {
        
        transform.position = firstPosition;
        rigidBody.isKinematic = true;
        yield return new WaitForSeconds(1f);
        rigidBody.useGravity = true;
        rigidBody.isKinematic=false;
    }
}
