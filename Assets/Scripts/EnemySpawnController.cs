using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [Header("Adjustable settings")]
    [SerializeField] private float timeToSpawn;
    [Space(15)]
    [SerializeField] private Transform enemyParent;
    [SerializeField] private Transform spawnPositionParent;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject player;

    #region Privat variables
    private float _timeCounter;
    private int _enemySpawnCounter;
    #endregion

    private void Awake()
    {
        Setup();
    }

    private void Setup()
    {
        _timeCounter = 0.0f;
        _enemySpawnCounter = 0;

        SpawnEnemy();
    }

    private void Update()
    {
        _timeCounter += Time.deltaTime;

        if (_timeCounter >= timeToSpawn)
        {
            _timeCounter = 0.0f;

            //SpawnEnemy();
        }

    }// end of update

    private void SpawnEnemy()
    {
        _enemySpawnCounter++;

        int spawnPositionIndex = UnityEngine.Random.Range(0, spawnPositionParent.transform.childCount);

        GameObject go = Instantiate(enemyPrefab, enemyParent);

        Enemy enemy = go.GetComponent<Enemy>();
        enemy.enabled = true;

        enemy.Player = player.transform;

        go.name = "Enemy" + _enemySpawnCounter;
        go.transform.position = spawnPositionParent.GetChild(spawnPositionIndex).transform.position;

    }

    


}
