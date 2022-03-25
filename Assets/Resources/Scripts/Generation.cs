using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{
    private float _spawnRadius = 7;

    [SerializeField] private Transform _pointTop;
    [SerializeField] private Transform _pointRight;

    [SerializeField] private GameObject[] _prefab;

    void FixedUpdate()
    {
        Vector2 spawnPos = GameObject.FindWithTag("Player").transform.position;
        spawnPos += new Vector2(_pointRight.position.x, _pointTop.position.y) * _spawnRadius;

        Instantiate(_prefab[UnityEngine.Random.Range(0, _prefab.Length)], spawnPos, Quaternion.identity);
    }
}
