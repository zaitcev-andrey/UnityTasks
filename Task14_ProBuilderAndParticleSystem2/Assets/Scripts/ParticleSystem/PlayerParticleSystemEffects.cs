using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticleSystemEffects : MonoBehaviour
{
    [SerializeField] private ParticleSystem _burstEffect;

    private CreateAndDestroyPlayer _playerCreator;

    private void Start()
    {
        _playerCreator = FindObjectOfType<CreateAndDestroyPlayer>();
    }

    public void PlayBurstAtDeath()
    {
        _burstEffect.transform.position = _playerCreator.PlayerPosition();
        _burstEffect.Play();
        StartCoroutine(_playerCreator.DestroyAndCreatePlayer());
    }
}
