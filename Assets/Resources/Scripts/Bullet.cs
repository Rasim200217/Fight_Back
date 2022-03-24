using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float _bulletForce = 5f;

    private Vector2 _direction;

    private void Start()
    {
        _direction = GameObject.Find("Dir").transform.position;
        transform.position = GameObject.Find("FirePoint").transform.position;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _direction, _bulletForce * Time.deltaTime);
        Destroy(gameObject, 1.5f);
    }

     void OnCollisionEnter2D(Collision2D other)
     {
    if (other.gameObject.CompareTag("Enemy"))
    {
       Destroy(gameObject);
    }
    }
}
