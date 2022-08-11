using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidsManager : SpawnManager
{
   
    [SerializeField] private float poolStartAmount = 15;
    [SerializeField] private AsteroidBehaviour prefab;
    [SerializeField] private List<AsteroidBehaviour> asteroidsPool;
    
    public override void Starting()
    {
        for (int i = 0; i < poolStartAmount; i++)
        {
            AsteroidBehaviour asteroid = Instantiate(prefab, transform);
            asteroidsPool.Add(asteroid);
            asteroid.gameObject.SetActive(false);
        }
    }

    public override void Spawn(Vector3 spawnPoint)
    {
        SpawnAsteroid(spawnPoint);
    }


    public void SpawnAsteroid(Vector3 spawnPoint)
    {
        GetFromPool().Init(this, spawnPoint, new Vector3(0,0,1));
    }

    public AsteroidBehaviour GetFromPool()
    {
        AsteroidBehaviour toExit;
        if (asteroidsPool.Count == 0)
        {
            toExit = Instantiate(prefab, transform);
        }
        else
        {
            toExit = asteroidsPool[^1];
            asteroidsPool.Remove(toExit);
        }
        return toExit;
    }

    public void ReturnToPool(AsteroidBehaviour toPool)
    {
        asteroidsPool.Add(toPool);
    }

    public void ResetAsteroid(AsteroidBehaviour toReset)
    {
        toReset.transform.SetParent(transform);
        toReset.transform.position = Vector3.zero;
    }

   
    
}
