using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager instance;

    private int _score;
    [FormerlySerializedAs("_levelNum")] public int levelNum;

    public bool spawn = true;

    public GameObject[] enemies;

    public Level[] level;

    public Text scoreCountText, scoreCountMaxText;
    public TextMeshProUGUI roundCompleted;

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
    
        TextHolder();
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
        roundCompleted.gameObject.SetActive(true);
        roundCompleted.text = "Волна " + (levelNum + 1) + " Пройдена!";

        if (level == null) 
        {
            SceneManager.LoadScene(1);
            spawn = false;
        }
   
            _score = 0;
            levelNum++;
            GameObject.FindWithTag("Player").GetComponent<Shooting>().currentWeapon = level[levelNum].weapon;
            DestroyAllEnemies();
            spawn = false;
            yield return new WaitForSeconds(2);
            roundCompleted.gameObject.SetActive(false);
            spawn = true;
    }

    void DestroyAllEnemies()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            Destroy(enemies[i].gameObject);
        }
    }

    void TextHolder()
    {
        scoreCountText.text = _score.ToString();
        scoreCountMaxText.text = level[levelNum].scoreMax.ToString();
    }
}
