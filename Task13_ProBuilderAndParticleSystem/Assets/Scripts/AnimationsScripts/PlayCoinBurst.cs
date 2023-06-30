using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCoinBurst : MonoBehaviour
{
    [SerializeField] private ParticleSystem _coinBurstParticleEffect;

    public void PlayBurst()
    {
        _coinBurstParticleEffect.Play();
    }
}
