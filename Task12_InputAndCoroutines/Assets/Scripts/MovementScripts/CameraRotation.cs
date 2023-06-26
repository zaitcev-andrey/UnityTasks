using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Vector3 _distanceFromPlayer;
    [SerializeField] private float _rotationSpeed;

    private float _rotationAroundX, _rotationAroundY;   
    private float _xRotation = 0f, _yRotation = 0f;

    void Start()
    {
        
    }

    private void Update()
    {
        _rotationAroundX = Input.GetAxis("Mouse Y") * _rotationSpeed * Time.deltaTime;
        _xRotation -= _rotationAroundX;
        _xRotation = Mathf.Clamp(_xRotation, -20f, 30f);

        _rotationAroundY = Input.GetAxis("Mouse X") * _rotationSpeed * Time.deltaTime;
        _yRotation += _rotationAroundY;
        _yRotation = Mathf.Clamp(_yRotation, -50f, 50f);

        transform.localRotation = Quaternion.Euler(_xRotation, _yRotation, 0);
        //transform.Rotate(-_rotationAroundX, _rotationAroundY, 0);
    }

    void LateUpdate()
    {
        //Vector3 positionToGo = _playerTransform.position + _distanceFromPlayer;
        //transform.position = Vector3.Lerp(transform.position, positionToGo, 1f);
        //transform.LookAt(_playerTransform.position);
    }
}
