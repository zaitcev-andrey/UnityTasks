using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingAndRotationForRocket : MonoBehaviour
{
    [SerializeField] private Transform _rocketTransform;

    [SerializeField] private Transform _point1Transform;
    [SerializeField] private Transform _point2Transform;
    [SerializeField] private Transform _point3Transform;
    [SerializeField] private Transform _point4Transform;
    [SerializeField] private Transform _point5Transform;
    [SerializeField] private Transform _point6Transform;
    [SerializeField] private Transform _point7Transform;

    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _movingSpeed;

    private List<Transform> _allPoints;
    private int _currentTargetIndex;
    private Vector3 _currentTarget;
    private bool _forwardMoving;

    void Start()
    {
        _allPoints = new List<Transform>()
        {
            _point1Transform,
            _point2Transform,
            _point3Transform,
            _point4Transform,
            _point5Transform,
            _point6Transform,
            _point7Transform
        };

        _currentTargetIndex = 0;
        _currentTarget = _allPoints[_currentTargetIndex].position;
        _rocketTransform.LookAt(_currentTarget);
    }

    void Update()
    {        
        _rocketTransform.Rotate(0, 0, _rotationSpeed * Time.deltaTime);

        _rocketTransform.position = Vector3.MoveTowards(_rocketTransform.position, _currentTarget, _movingSpeed * Time.deltaTime);
        if(_rocketTransform.position == _currentTarget)
        {
            if (_currentTargetIndex + 1 == _allPoints.Count)
                _forwardMoving = false;
            else if (_currentTargetIndex == 0)
                _forwardMoving = true;

            if(_forwardMoving)
                _currentTargetIndex++;
            else _currentTargetIndex--;

            _currentTarget = _allPoints[_currentTargetIndex].position;
            _rocketTransform.LookAt(_currentTarget);
        }
    }
}
