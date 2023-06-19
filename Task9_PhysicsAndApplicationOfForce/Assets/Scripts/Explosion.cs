using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _power;
    [SerializeField] private float _timeToExplosion;

    private Rigidbody[] _allRigidbodies;
    private float _currentTimeToExplosion;

    void Start()
    {
        _currentTimeToExplosion = _timeToExplosion;
        _allRigidbodies = FindObjectsOfType<Rigidbody>();
    }

    void Update()
    {
        _currentTimeToExplosion -= Time.deltaTime;

        if(_currentTimeToExplosion < 0)
        {
            Boom();
            _currentTimeToExplosion = _timeToExplosion;
        }
    }

    private void Boom()
    {
        foreach (var rb in _allRigidbodies)
        {
            float distance = Vector3.Distance(transform.position, rb.transform.position);
            if(distance < _radius)
            {
                Vector3 direction = rb.transform.position - transform.position;
                rb.AddForce(direction.normalized * _power * (_radius - distance), ForceMode.Impulse);
            }
        }
        
    }
}
