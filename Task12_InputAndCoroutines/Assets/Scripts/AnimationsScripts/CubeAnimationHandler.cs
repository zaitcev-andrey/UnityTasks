using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeAnimationHandler : MonoBehaviour
{
    private Animator _anim;
    [SerializeField] private Rigidbody _rb;
    void Start()
    {
        _anim = GetComponent<Animator>();
        //_rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _anim.SetFloat("Velocity", _rb.velocity.magnitude);
    }
}
