using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{

    public KeyCode input;
    private float targetPressed,targetRelease;
    private JointSpring jointSpring;
    private HingeJoint hinge;

    private void Start()
    {
        hinge = GetComponent<HingeJoint>();
        jointSpring = hinge.spring;
        targetPressed = hinge.limits.max;
        targetRelease = hinge.limits.min;
    }


    private void Update()
    {
        ReadInput();
    }

    private void ReadInput()
    {
        if (Input.GetKey(input))
        {
            jointSpring.targetPosition = targetPressed;
        }
        else
        {
            jointSpring.targetPosition = targetRelease;
        }
        hinge.spring = jointSpring;
    }
}
