using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float returnTime;
    public float followSpeed;
    public float length;

    public Transform target;

    private Vector3 defaultPosition;

    public bool hasTarget { get { return target != null; } }

    private void Start()
    {
        defaultPosition = transform.position;
        target = null;
    }

    private void Update()
    {
        if (hasTarget)
        {
            Vector3 targetToCameraDir = transform.rotation * -Vector3.forward;
            Vector3 targetPosition = target.position + ((targetToCameraDir) * length);
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }
    public void FollowAtTarget(Transform targetT,float targetLength)
    {
        StopAllCoroutines();
        target = targetT;
        length = targetLength;
         
    }

    public void GoBackToDefault()
    {
        target = null;
        StopAllCoroutines();
        StartCoroutine(MovePosition(defaultPosition, returnTime));
    }

    private IEnumerator MovePosition(Vector3 target,float time)
    {
        float timer = 0f;
        Vector3 start = transform.position;

        while(timer < time)
        {
            transform.position = Vector3.Lerp(start,target, Mathf.SmoothStep(0.0f,1.0f,timer/time));
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = target;
    }
}
