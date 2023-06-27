using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAndRotationAroundAxis : MonoBehaviour
{
    [SerializeField, Range(100, 300)] private float _rotationSpeed;

    public float GetRotationAroundX()
    {
        return Input.GetAxis("Mouse Y") * _rotationSpeed * Time.deltaTime;
    }

    public float GetRotationAroundY()
    {
        return Input.GetAxis("Mouse X") * _rotationSpeed * Time.deltaTime;
    }
}
