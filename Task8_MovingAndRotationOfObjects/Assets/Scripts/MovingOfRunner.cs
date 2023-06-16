using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingOfRunner : MonoBehaviour
{
    [SerializeField] private Transform[] _allRunners;

    // Организуем передачу эстафетной палочки
    [SerializeField] private Transform _stick;
    [SerializeField] private Transform[] _allPlacesForStick;

    [SerializeField] private float _movingSpeed;
    [SerializeField] private float _passDistance;

    private int _currentRunnerIndex;
    private int _currentTargetIndex;
    private Transform _currentRunner;
    private Vector3 _currentTarget;

    private Vector3 _startPosition;
    private bool _isMoving = true;

    void Start()
    {
        _currentRunnerIndex = 0;
        _currentTargetIndex = 1;
        _currentRunner = _allRunners[0];
        _startPosition = _currentRunner.position;
        _currentTarget = _allRunners[1].position;
        _currentRunner.LookAt(_currentTarget);
    }

    void Update()
    {
        _currentRunner.position = Vector3.MoveTowards(_currentRunner.position, _currentTarget, _movingSpeed * Time.deltaTime);

        if(_isMoving && Vector3.Distance(_currentRunner.position, _currentTarget) <= _passDistance)
        {
            _currentRunnerIndex++;
            if (_currentTargetIndex + 1 == _allRunners.Length)
            {
                _currentTarget = _startPosition;
                _isMoving = false;
            }
            else
            {
                _currentTargetIndex++;
                _currentTarget = _allRunners[_currentTargetIndex].position;
            }

            _currentRunner = _allRunners[_currentRunnerIndex];

            _currentRunner.LookAt(_currentTarget);

            // Передаём палочку
            _stick.position = _allPlacesForStick[_currentRunnerIndex].position;
            _stick.SetParent(_allPlacesForStick[_currentRunnerIndex]);
        }
    }
}
