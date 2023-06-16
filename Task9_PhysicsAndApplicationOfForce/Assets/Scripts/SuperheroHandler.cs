using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperheroHandler : MonoBehaviour
{
    [SerializeField] private Transform _enemy0;
    [SerializeField] private Transform _enemy1;
    [SerializeField] private Transform _enemy2;
    [SerializeField] private Transform _enemy3;
    [SerializeField] private Transform _enemy4;
    [SerializeField] private Transform _enemy5;
    [SerializeField] private Transform _enemy6;

    [SerializeField] private Transform _friend0;
    [SerializeField] private Transform _friend1;
    [SerializeField] private Transform _friend2;
    [SerializeField] private Transform _friend3;
    [SerializeField] private Transform _friend4;
    [SerializeField] private Transform _friend5;
    [SerializeField] private Transform _friend6;
    [SerializeField] private Transform _friend7;
    [SerializeField] private Transform _friend8;
    [SerializeField] private Transform _friend9;
    [SerializeField] private Transform _friend10;
    [SerializeField] private Transform _friend11;
    [SerializeField] private Transform _friend12;
    [SerializeField] private Transform _friend13;
    [SerializeField] private Transform _friend14;
    [SerializeField] private Transform _friend15;

    [SerializeField] private float _superheroSpeed;
    [SerializeField] private float _strengthOfPunch;

    private List<Transform> _allEnemies;
    private List<Transform> _allFriends;

    private Vector3 _currentTarget;
    private int _currentEnemyIndex;

    private Rigidbody _rigidbodyOfSuperhero;
    private HashSet<GameObject> _defeatedEnemies;

    private Vector3 _startPosition;

    void Start()
    {
        _allEnemies = new List<Transform>()
        {
            _enemy0,
            _enemy1,
            _enemy2,
            _enemy3,
            _enemy4,
            _enemy5,
            _enemy6,
        };

        _allFriends = new List<Transform>()
        {
            _friend0,
            _friend1,
            _friend2,
            _friend3,
            _friend4,
            _friend5,
            _friend6,
            _friend7,
            _friend8,
            _friend9,
            _friend10,
            _friend11,
            _friend12,
            _friend13,
            _friend14,
            _friend15
        };
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
        if(!(_currentEnemyIndex == _allEnemies.Count && transform.position == _startPosition))
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
                if (_currentEnemyIndex != _allEnemies.Count)
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
