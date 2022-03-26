using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
   public GameObject[] weapons;

   [SerializeField] private float _xBound, _yBound;
   [SerializeField] private float _spawnRadius;
   [SerializeField] private int _timeSpawn = 5;

   
   private void Start()
   {
      StartCoroutine(SpawnWeapon());
   }

   IEnumerator SpawnWeapon()
   {
      yield return new WaitForSeconds(_timeSpawn);
      
      Vector2 spawnPos = GameObject.FindWithTag("Player").transform.position;
      spawnPos += UnityEngine.Random.insideUnitCircle.normalized * _spawnRadius;
      
      /*Vector2 spawnPoint = new Vector2(UnityEngine.Random.Range(-_xBound, _xBound),
         UnityEngine.Random.Range(-_yBound, _yBound));*/
      if(GameObject.FindGameObjectsWithTag("Weapon").Length < 3)
      Instantiate(weapons[UnityEngine.Random.Range(0, weapons.Length)], spawnPos, Quaternion.identity);
      StartCoroutine(SpawnWeapon());
   }
}
