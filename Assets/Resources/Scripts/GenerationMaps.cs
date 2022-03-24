using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationMaps : MonoBehaviour
{
    public GameObject _prefabMaps;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(_prefabMaps, transform.position, Quaternion.identity);
        }
    }

}
