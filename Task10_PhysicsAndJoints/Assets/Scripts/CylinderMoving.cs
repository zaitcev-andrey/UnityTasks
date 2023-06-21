using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderMoving : MonoBehaviour
{
    [SerializeField] private float _movingSpeed;
    [SerializeField] private Transform _leftEdge;
    [SerializeField] private Transform _rightEdge;

    private float _minPositionX;
    private float _maxPositionX;

    private bool _moveToRight;

    void Start()
    {
        // эти значения взяты с учётом ширины доски
        _minPositionX = _leftEdge.transform.position.x;
        _maxPositionX = _rightEdge.transform.position.x;

        _moveToRight = true;
    }

    void Update()
    {
        if(_moveToRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, _rightEdge.position, _movingSpeed * Time.deltaTime);
            if(transform.position.x == _maxPositionX)
                _moveToRight = false;
            
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _leftEdge.position, _movingSpeed * Time.deltaTime);
            if (transform.position.x == _minPositionX)
                _moveToRight = true;
        }
        
    }
}
