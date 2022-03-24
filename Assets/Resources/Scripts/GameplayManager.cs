using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager instance;

    private int _score;
    [FormerlySerializedAs("_levelNum")] public int levelNum;

    public bool spawn = true;

    public GameObject[] enemies;

    public Level[] level;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        levelNum = 0;
    }

    private void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (_score >= level[levelNum].scoreMax)
        {
           StartCoroutine(UpgradeThePlayer());
        }
    }

    public void AddScore(int amount)
    {
        _score += amount;
    }

   IEnumerator UpgradeThePlayer()
    {
        _score = 0;
        levelNum++;
        GameObject.FindWithTag("Player").GetComponent<Shooting>().currentWeapon = level[levelNum].weapon;
        DestroyAllEnemies();
        spawn = false;
        yield return new WaitForSeconds(2);
        spawn = true;
    }

    void DestroyAllEnemies()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            Destroy(enemies[i].gameObject);
        }
    }
}
