using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForCoin : MonoBehaviour
{
    [SerializeField] private Animator _anim;

    private void OnTriggerEnter(Collider other)
    {
        _anim.SetTrigger("Collect");
        Destroy(gameObject, 0.5f);
    }
}
