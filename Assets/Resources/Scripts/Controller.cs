using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _speedRotate;
    [SerializeField] private int _health;

    private bool _hit = true;
    
    private Rigidbody2D _rigidbody2D;
    private Camera _camera;
    
    private Vector3 _mousePosition;


    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _camera = Camera.main;
    }

    private void FixedUpdate()
    {
        Move();
        CursorRotate();
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        
        _rigidbody2D.velocity = new Vector2(x, y) * _speed;


        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -35f, 35f),
            Mathf.Clamp(transform.position.y, -19f, 19f));
    }

    private void CursorRotate()
    {
        _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = _mousePosition - transform.position;
        lookDir.Normalize();
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle * _speedRotate);
    }

    IEnumerator HitBoxOff()
    {
        _hit = false;
        yield return new WaitForSeconds(1.5f);
        _hit = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if(_hit) 
            {
                StartCoroutine(HitBoxOff());
                _health--;

                Destroy(GameObject.Find("Life_Con").transform.GetChild(0).gameObject);

                if(_health < 1)
                {
                    StartCoroutine(Death());
                }
            }
        }
    }

    IEnumerator Death()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(2);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}


