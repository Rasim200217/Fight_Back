using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    private Transform _player;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    private void Update()
    {
        transform.position = new Vector3(_player.position.x, _player.position.y, transform.position.z);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -27f, 27f),
            Mathf.Clamp(transform.position.y, -14.8f, 14.8f), transform.position.z);
    }
}
