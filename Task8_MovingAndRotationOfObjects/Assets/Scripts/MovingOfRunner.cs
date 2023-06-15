using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingOfRunner : MonoBehaviour
{
    [SerializeField] private Transform _runner1;
    [SerializeField] private Transform _runner2;
    [SerializeField] private Transform _runner3;
    [SerializeField] private Transform _runner4;
    [SerializeField] private Transform _runner5;
    [SerializeField] private Transform _runner6;

    // Организуем передачу эстафетной палочки
    [SerializeField] private Transform _stick;
    [SerializeField] private Transform _placeForStickOfRunner1;
    [SerializeField] private Transform _placeForStickOfRunner2;
    [SerializeField] private Transform _placeForStickOfRunner3;
    [SerializeField] private Transform _placeForStickOfRunner4;
    [SerializeField] private Transform _placeForStickOfRunner5;
    [SerializeField] private Transform _placeForStickOfRunner6;

    [SerializeField] private float _movingSpeed;

    private int _currentRunnerIndex;
    private int _currentTargetIndex;
    private Transform _currentRunner;
    private Vector3 _currentTarget;
    private List<Transform> _allRunners;
    private List<Transform> _allPlacesForStick;

    private Vector3 _startPosition;
    private bool _isMoving = true;

    void Start()
    {
        _allRunners = new List<Transform>()
        { 
            _runner1,
            _runner2,
            _runner3,
            _runner4,
            _runner5,
            _runner6,
        };
        _allPlacesForStick = new List<Transform>()
        {
            _placeForStickOfRunner1,
            _placeForStickOfRunner2,
            _placeForStickOfRunner3,
            _placeForStickOfRunner4,
            _placeForStickOfRunner5,
            _placeForStickOfRunner6
        };

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

        if(_isMoving && _currentRunner.position == _currentTarget)
        {
            _currentRunnerIndex++;
            if (_currentTargetIndex + 1 == _allRunners.Count)
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
