using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Vector3 _distanceFromPlayer;
    private float _mouseX, _mouseY;

    void Start()
    {
        
    }

    void LateUpdate()
    {
        Vector3 positionToGo = _playerTransform.position + _distanceFromPlayer;
        transform.position = Vector3.Lerp(transform.position, positionToGo, 1f);
        transform.LookAt(_playerTransform.position);
    }
}
