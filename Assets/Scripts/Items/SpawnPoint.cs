using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject _spawnPrefab;
    [SerializeField] private float _timeBetweenSpawn = 5;

    private GameObject _spawnedObject;

    private void Start()
    {
        _spawnedObject = null;
        
        StartCoroutine(LaunchSpawner());
    }

    private IEnumerator LaunchSpawner()
    {
        while (true)
        {
            SpawnObject();

            yield return new WaitUntil(() => _spawnedObject == null);
            yield return new WaitForSeconds(_timeBetweenSpawn);
        }
    }

    private void SpawnObject()
    {
        _spawnedObject = Instantiate(_spawnPrefab, this.transform);
    }
}