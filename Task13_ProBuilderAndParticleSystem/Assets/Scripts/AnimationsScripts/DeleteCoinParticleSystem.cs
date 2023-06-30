using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteCoinParticleSystem : MonoBehaviour
{
    [SerializeField] private ParticleSystem _coinLifeParticleEffect;

    public void DeleteCoinEffect()
    {
        Destroy(_coinLifeParticleEffect);
    }
}
