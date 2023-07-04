using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameWithFireworks : MonoBehaviour
{
    [SerializeField] private ParticleSystem _fireWork1;
    [SerializeField] private ParticleSystem _fireWork2;

    [SerializeField] private Transform _placeForFirework1;
    [SerializeField] private Transform _placeForFirework2;

    private ManagerForCanvasWithInformationForPlayer _manager;
    private bool _isEnded = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!_isEnded)
        {
            LightTheFireWorks();
            _manager = FindObjectOfType<ManagerForCanvasWithInformationForPlayer>();
            _manager.SwitchInformation();
            _isEnded = true;
        }
    }

    private void LightTheFireWorks()
    {
        _fireWork1.transform.position = _placeForFirework1.position;
        _fireWork2.transform.position = _placeForFirework2.position;
        _fireWork1.Play();
        _fireWork2.Play();
    }
}
