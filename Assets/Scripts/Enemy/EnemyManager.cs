using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : SpawnManager
{
    [SerializeField] private ShootingEnemy prefab;
    private ShootingEnemy currentSpawner;

    public override void Spawn(Vector3 spawnPoint)
    {
        if(currentSpawner != null) return;
        currentSpawner = Instantiate(prefab, transform);
        currentSpawner.Init(this,spawnPoint,new Vector3(0,0,1));
    }

    public void CanBeSpawned()
    {
        currentSpawner = null;
    }
}
