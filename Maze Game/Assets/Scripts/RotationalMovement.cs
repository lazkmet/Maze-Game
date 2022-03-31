using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationalMovement : MonoBehaviour
{
    [Range(0f, 1f)]
    public float threshold = 0f;
    public float rotationSpeed = 0f;
    public char rotationAxis = 'z';
    private Transform toRotate;
    private Quaternion startRotation;
    private float currentRotation;
    private float previousInput = 0; 
    private void Awake()
    {
        toRotate = this.transform;
        startRotation = toRotate.rotation;
    }
    private void Update()
    {
        float input = Input.GetAxis("Horizontal");
        float dampedThreshold = Mathf.Abs(previousInput) > Mathf.Abs(input) ? 0.7f : threshold;
        previousInput = input;
        input = (Mathf.Abs(input) > dampedThreshold) ? Mathf.Clamp(2f * input, -1, 1) : 0;
        currentRotation = input * rotationSpeed * Time.deltaTime;
        switch (rotationAxis) {
            case 'x':
                toRotate.Rotate(new Vector3(currentRotation, 0, 0));
                break;
            case 'y':
                toRotate.Rotate(new Vector3(0, currentRotation, 0));
                break;
            case 'z':
                toRotate.Rotate(new Vector3(0, 0, currentRotation));
                break;
            default:
                throw new System.NotImplementedException();
        }
    }
    public void Reset()
    {
        previousInput = 0;
        toRotate.rotation = startRotation;
        this.enabled = true;
    }
}
