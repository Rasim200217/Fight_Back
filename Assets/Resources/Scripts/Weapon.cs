using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public Sprite currentWeapon;
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    public int damage = 20;


    public void Shoot()
    {
        Instantiate(bulletPrefab, GameObject.Find("FirePoint").transform.position, Shooting.shooting._firePoint.rotation);
    }
}
