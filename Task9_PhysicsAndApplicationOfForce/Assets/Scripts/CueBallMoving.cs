using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueBallMoving : MonoBehaviour
{
    [SerializeField] private float _cueBallSpeed;

    void Start()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * _cueBallSpeed, ForceMode.Impulse);
    }
}
