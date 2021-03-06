﻿using UnityEngine;
using UnityEngine.Networking;

public class EnemiesSpawner : NetworkBehaviour
{
    public GameObject enemyPrefab;
    public int numberOfEnemies;

    public override void OnStartServer()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            var spawnPosition = new Vector3(
                Random.Range(-8.0f, 8.0f),
                0.0f,
                Random.Range(-8.0f, 8.0f));
            
            var enemy = (GameObject)Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            NetworkServer.Spawn(enemy);
        }
    }
}
