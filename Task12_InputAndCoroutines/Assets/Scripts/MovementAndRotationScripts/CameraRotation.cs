using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Transform _pivotForCamera;
    [SerializeField] private Vector3 _distanceFromPlayer;

    private InputAndRotationAroundAxis _inputs;

    //private float _rotationAroundX;
    private float _rotationAroundY;
    //private float _xRotation = 0f, _yRotation = 0f;

    private void Start()
    {
        _inputs = FindObjectOfType<InputAndRotationAroundAxis>();
    }

    private void Update()
    {
        CameraRotationAroundPoint();
    }

    void LateUpdate()
    {
        CameraLerpPlayer();
    }

    private void GetRotation()
    {
        //_rotationAroundX = _inputs.GetRotationAroundX();
        _rotationAroundY = _inputs.GetRotationAroundY();
    }

    private void CameraClampRotation()
    {
        //GetRotation();

        //_xRotation -= _rotationAroundX;
        //_xRotation = Mathf.Clamp(_xRotation, -20f, 30f);

        //_yRotation += _rotationAroundY;
        //_yRotation = Mathf.Clamp(_yRotation, -50f, 50f);

        //transform.localRotation = Quaternion.Euler(_xRotation, _yRotation, 0);
    }

    private void CameraRotationAroundPoint()
    {
        _rotationAroundY = _inputs.GetRotationAroundY();
        _pivotForCamera.Rotate(0, _rotationAroundY, 0);
    }

    private void CameraLerpPlayer()
    {
        Vector3 positionToGo = _playerTransform.position + _distanceFromPlayer;
        _pivotForCamera.position = Vector3.Lerp(_pivotForCamera.position, positionToGo, 1f);
        transform.LookAt(_playerTransform.position);
    }
}
