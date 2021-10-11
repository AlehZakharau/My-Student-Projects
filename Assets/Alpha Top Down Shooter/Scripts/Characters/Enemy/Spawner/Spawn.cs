using System;
using System.Collections;
using System.Collections.Generic;
using Alpha.Characters;
using Alpha.Characters.Enemy;
using Alpha.Spawner;
using Alpha.UI;
using Characters.Enemy;
using Pool;
using UnityEngine;
using UnityEngine.AI;

public class Spawn : MonoBehaviour
{
    [SerializeField] private Wave[] waves;
    [SerializeField] private Transform[] spawnPosition;
    [SerializeField] private Transform player;
    [SerializeField] private float delayBetweenWave = 10;
    [SerializeField] private float delayBetweenSpawn = 1;
    [SerializeField] private EnemyPoolSO georgePool;
    [SerializeField] private EnemyPoolSO stanPool;
    [SerializeField] private EnemyPoolSO mikePool;
    [SerializeField] private EnemyPoolSO leelaPool;
    [SerializeField] private InfoUI ui;
    [SerializeField] private EndGameMenuUI endGame;
    
    private List<Enemy> enemies = new List<Enemy>();

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }
    
    
    private IEnumerator SpawnWaves()
    {
        //Debug.Log($"Wave {waves.Length}");
        for (int i = 0; i < waves.Length; i++)
        {
            var george = waves[i].georgeAmount;
            var stan = waves[i].stanAmount;
            var mike = waves[i].mikeAmount;
            var leela = waves[i].leelaAmount;
            var small = (float)(george + stan + mike + leela) / spawnPosition.Length;
            var smallWave = Mathf.Ceil(small);
            //Debug.Log($"Small Wave {small} {smallWave}");
            for (int j = 0; j < smallWave; j++)
            {
                Enemy enemy;
                for (int k = 0; k < spawnPosition.Length; k++)
                {
                    if (george > 0)
                    {
                        enemy = georgePool.Request();
                        george--;
                        //Debug.Log($"George: {george}");
                    }
                    else if (stan > 0)
                    {
                        stan--;
                        enemy = stanPool.Request();
                        //Debug.Log($"Stan: {stan}");
                    
                    }
                    else if (mike > 0)
                    {
                        mike--;
                        enemy = mikePool.Request();
                        //Debug.Log($"Mike: {leela}");
                        enemy.victoryCondition.EndGame = endGame;

                    }
                    else if (leela > 0)
                    {
                        leela--;
                        enemy = leelaPool.Request();
                        //Debug.Log($"Leela: {leela}");
                    
                    }
                    else
                        continue;
                    enemy.navMeshAgent.Warp(spawnPosition[k].position);
                    enemy.transform.rotation = Quaternion.LookRotation(player.position);
                    enemy.georgeMovement.Player = player;
                    enemy.enemyHealth.Ui = ui;
                    enemies.Add(enemy);
                }
                yield return new WaitForSeconds(delayBetweenSpawn);
            }
            yield return new WaitForSeconds(delayBetweenWave);
        }
    }

    public void SpawnEnemies()
    {
        foreach (var enemy in enemies)
        {
            Destroy(enemy);
        }
        StopCoroutine(SpawnWaves());
        StartCoroutine(SpawnWaves());
    }
}
