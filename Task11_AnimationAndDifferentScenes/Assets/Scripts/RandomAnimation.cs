using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class RandomAnimation : MonoBehaviour
{
    private Animator _anim;
    private System.Random _rand;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _rand = new System.Random();
    }

    private void Start()
    {
        ChangeAnimation();
    }

    public void ChangeAnimation()
    {
        int value = _rand.Next(0, 3);
        Debug.Log($"RobotAnimation: {value}");
        _anim.SetInteger("animationId", value);
    }
}
