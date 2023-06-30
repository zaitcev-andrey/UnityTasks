using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreateAndDestroyPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private Transform _startRespawnPointTransform;
    [SerializeField] private Transform _respawnPointTransform;

    private GameObject _player;

    void Awake()
    {
        _player = Instantiate(_playerPrefab, _startRespawnPointTransform.position, _startRespawnPointTransform.rotation);
    }

    private void CreatePlayer()
    {
        _player = Instantiate(_playerPrefab, _respawnPointTransform.position, _respawnPointTransform.rotation);
    }

    private void DestroyPlayer()
    {
        Destroy(_player);
    }

    public IEnumerator DestroyAndCreatePlayer()
    {
        DestroyPlayer();
        yield return new WaitForSecondsRealtime(3);
        CreatePlayer();
    }

    public Vector3 PlayerPosition()
    {
        return _player.transform.position;
    }

    public GameObject GetPlayer()
    {
        return _player;
    }
}
