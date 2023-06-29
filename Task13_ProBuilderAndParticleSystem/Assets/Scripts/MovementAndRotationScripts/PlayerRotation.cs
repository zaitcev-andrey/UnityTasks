using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    private InputAndRotationAroundAxis _inputs;

    //private float _rotationAroundX;
    private float _rotationAroundY;

    private void Start()
    {
        _inputs = FindObjectOfType<InputAndRotationAroundAxis>();
    }
    void Update()
    {
        PlayerRotationAroundY();
    }

    private void PlayerRotationAroundY()
    {
        _rotationAroundY = _inputs.GetRotationAroundY();
        transform.Rotate(0, _rotationAroundY, 0);
    }
}
