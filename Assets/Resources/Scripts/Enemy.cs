using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    
    [SerializeField] private Transform _target;
    [SerializeField] private float _moveSpeed = 5f;

    private float _repelRange = .5f;
    private float _repelAmount = 1f;

    [SerializeField] private int _health;

   public int scoreReward;

    private Rigidbody2D _rigidbody2D;
    Vector2 mov;

    private List<Rigidbody2D> _enemyRb;


    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _target = GameObject.FindGameObjectWithTag("Player").transform;

        if (_enemyRb == null) _enemyRb = new List<Rigidbody2D>();

        _enemyRb.Add(_rigidbody2D);
    }

    private void Update()
    {
        if (_health < 1)
        {
            GameplayManager.instance.AddScore(scoreReward);
            Destroy(gameObject);
        }
         

        MoveEnemy();
    }

    private void MoveEnemy()
    {
        Vector3 dir = _target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        _rigidbody2D.rotation = angle;
        dir.Normalize();
        mov = dir;

        _rigidbody2D.MovePosition(transform.position + (dir * _moveSpeed * Time.deltaTime));
    }

    private void OnDestroy()
    {
        _enemyRb.Remove(_rigidbody2D);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Bullet"))
        {
            _health -= Shooting.shooting.currentWeapon.damage;
            Destroy(collision.gameObject);
        }   
    }

    private void FixedUpdate()
    {
        Vector2 repelForce = Vector2.zero;

        foreach (Rigidbody2D enemy in _enemyRb)
        {
            if (enemy == _rigidbody2D) continue;

           /* if(Vector2.Distance(enemy.position, _rigidbody2D.position) <= _repelRange)
            {
                Vector2 repelDirection = (_rigidbody2D.position - enemy.position).normalized;
                repelForce += repelDirection;
            }*/
        }
    }
}
