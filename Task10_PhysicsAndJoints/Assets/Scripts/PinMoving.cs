using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinMoving : MonoBehaviour
{
    [SerializeField] private HingeJoint _hingeJoint;
    [SerializeField] private float _timeToHit;

    private float _currentTimeToHit;

    void Start()
    {
        _currentTimeToHit = _timeToHit;
    }

    void Update()
    {
        Moving();
    }

    private void Moving()
    {
        _currentTimeToHit -= Time.deltaTime;
        JointSpring spring = _hingeJoint.spring;
        if (_currentTimeToHit < 0)
        {
            spring.targetPosition = -90f;
            _hingeJoint.spring = spring;
            _currentTimeToHit = _timeToHit;
        }
        else
        {
            spring.targetPosition = spring.targetPosition + (Time.deltaTime / _timeToHit * 90f);
            _hingeJoint.spring = spring;
        }
    }
}
