using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = Unity.Mathematics.Random;


public class RandomSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnRadius = 7;
    [SerializeField] private float _time = 1.5f;

    public GameObject[] _enemiesPrefabs;


    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {

        Vector2 spawnPos = GameObject.FindWithTag("Player").transform.position;
        spawnPos += UnityEngine.Random.insideUnitCircle.normalized * _spawnRadius;

        if (GameplayManager.instance.spawn == true)
        {
            Instantiate(_enemiesPrefabs[UnityEngine.Random.Range(0, _enemiesPrefabs.Length)], spawnPos, Quaternion.identity);
        }

        yield return new WaitForSeconds(_time);
        StartCoroutine(SpawnEnemy());
        

    }
}
