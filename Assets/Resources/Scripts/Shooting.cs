using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform _firePoint;
    public GameObject _bulletPrefab;

    public static Shooting shooting;

    public Weapon currentWeapon;

    private float nextTimeOfFire = 0f;


    private void Awake()
    {
        shooting = this;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if(Time.time >= nextTimeOfFire)
        {
            currentWeapon.Shoot();
            nextTimeOfFire = Time.time + 1 / currentWeapon.fireRate;
        }
    }
}
