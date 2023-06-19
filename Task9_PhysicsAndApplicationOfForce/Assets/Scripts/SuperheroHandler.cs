using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperheroHandler : MonoBehaviour
{
    [SerializeField] private Transform[] _allEnemies;
    [SerializeField] private Transform[] _allFriends;

    [SerializeField] private float _superheroSpeed;
    [SerializeField] private float _strengthOfPunch;

    private Vector3 _currentTarget;
    private int _currentEnemyIndex;

    private Rigidbody _rigidbodyOfSuperhero;
    private HashSet<GameObject> _defeatedEnemies;

    private Vector3 _startPosition;

    void Start()
    {
        _defeatedEnemies = new HashSet<GameObject>();
        _startPosition = transform.position;

        _currentEnemyIndex = 0;
        _currentTarget = _allEnemies[_currentEnemyIndex].position;
        transform.LookAt(_currentTarget);

        _rigidbodyOfSuperhero = transform.GetComponent<Rigidbody>();
    }

    void Update()
    {
        UpdateLookAtOnSuperheroForOthers();

        UpdateMovingAndLookAtOfSuperhero();
    }

    private void UpdateLookAtOnSuperheroForOthers()
    {
        foreach (Transform enemy in _allEnemies)
        {
            enemy.LookAt(transform);
        }
        foreach (Transform friend in _allFriends)
        {
            friend.LookAt(transform);
        }
    }

    private void UpdateMovingAndLookAtOfSuperhero()
    {
        if(!(_currentEnemyIndex == _allEnemies.Length && transform.position == _startPosition))
            transform.position = Vector3.MoveTowards(transform.position, _currentTarget, _superheroSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody && collision.gameObject.layer == 7)
        {
            //Debug.Log("Удар");
            Vector3 direction = collision.gameObject.GetComponent<Transform>().position - transform.position;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(direction.normalized * _strengthOfPunch, ForceMode.Impulse);
            
            // без такой проверки и добавления в HashSet будет работать неправильно
            if(!_defeatedEnemies.Contains(collision.gameObject))
            {
                _currentEnemyIndex++;
                if (_currentEnemyIndex != _allEnemies.Length)
                {
                    _currentTarget = _allEnemies[_currentEnemyIndex].position;
                }
                else
                {
                    _currentTarget = _startPosition;
                }
                transform.LookAt(_currentTarget);
            }
            
            _defeatedEnemies.Add(collision.gameObject);
        }
    }
}
