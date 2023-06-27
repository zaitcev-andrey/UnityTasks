using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GlobalInputVars;
using System.Threading;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(5, 20)] private float _speed;

    private Rigidbody _playerRigidbody;
    private float _x, _z;
    private Vector3 _movement;

    private InputAndRotationAroundAxis _inputs;
    private Quaternion _quaternionAroundYForForce = Quaternion.identity;
    private float _rotationAroundY;

    void Start()
    {
        _inputs = FindObjectOfType<InputAndRotationAroundAxis>();
        _playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        GetQuaternionForForce();
        SetMovementVector();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void GetQuaternionForForce()
    {
        _rotationAroundY += _inputs.GetRotationAroundY();
        _quaternionAroundYForForce = Quaternion.AngleAxis(_rotationAroundY, Vector3.up);
    }

    private void SetMovementVector()
    {
        _x = Input.GetAxis(GlobalInputVars.GlobalStringVars.HORIZONTAL_AXIS);
        _z = Input.GetAxis(GlobalInputVars.GlobalStringVars.VERTICAL_AXIS);
        // ѕоскольку движение пишетс€ дл€ сферы, а дл€ неЄ не сделать AddRelativeForce, нам нужно изменить вектор движени€ с учЄтом поворота камеры
        // Ёто достигаетс€ умножением на кватернион поворота вокруг оси Y
        _movement = _quaternionAroundYForForce * new Vector3(_x, 0, _z).normalized * _speed;
    }
    private void Movement()
    {
        _playerRigidbody.AddForce(_movement);
    }
}
