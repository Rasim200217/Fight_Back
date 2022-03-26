using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeacponPickUp : MonoBehaviour
{
    public Weapon weapon;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Shooting>().currentWeapon = weapon;
            other.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = weapon.currentWeapon;
            Destroy(gameObject);
        }
    }
}
