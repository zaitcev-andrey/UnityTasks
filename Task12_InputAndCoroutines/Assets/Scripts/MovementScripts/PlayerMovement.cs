using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PlayerInputs;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(5, 20)] private float _speed;

    private Rigidbody _playerRigidbody;
    private float _x, _z;
    private Vector3 _movement;

    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        SetMovementVector();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void SetMovementVector()
    {
        _x = Input.GetAxis(PlayerInputs.GlobalStringVars.HORIZONTAL_AXIS);
        _z = Input.GetAxis(PlayerInputs.GlobalStringVars.VERTICAL_AXIS);
        _movement = new Vector3(_x, 0, _z).normalized * _speed;
    }
    private void Movement()
    {
        _playerRigidbody.AddForce(_movement);
    }
}
