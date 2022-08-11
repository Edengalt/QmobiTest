using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnManager : MonoBehaviour
{
    protected Vector3 Xmin;
    protected Vector3 Ymax;
    protected float spawnDelayTimer;
    [SerializeField] protected float spawnDelay = 2;
    
    private void Start()
    {
        spawnDelayTimer = spawnDelay;
        Camera camera = Camera.main;
        Xmin = camera.ScreenToWorldPoint(new Vector3 (0f, 0f, 1));
        Ymax = camera.ScreenToWorldPoint(new Vector3(camera.pixelWidth, camera.pixelHeight, 1));
        Starting();

    }
    
    private void Update()
    {
        spawnDelayTimer -= Time.deltaTime;
        if (spawnDelayTimer <= 0)
        {
            Spawn(CalculateSpawnPosition());
            spawnDelayTimer = spawnDelay;
        }
    }
    public virtual void Starting(){}

    public abstract void Spawn(Vector3 spawnPoint);

    public Vector3 CalculateSpawnPosition()
    {
        Vector3 spawnPoint = Vector3.zero;
        if (Random.Range(0f, 100f) < 50)
        {
            if (Random.Range(0f, 100f) < 50)
                spawnPoint = AdjustSpawnPoint(Xmin.x - 2, Random.Range(Xmin.y, Ymax.y));
            else
                spawnPoint = AdjustSpawnPoint(Ymax.x + 2, Random.Range(Xmin.y, Ymax.y));
        }
        else
        {
            if (Random.Range(0f, 100f) < 50)
                spawnPoint = AdjustSpawnPoint(Random.Range(Xmin.x, Ymax.x), Xmin.y - 2);
            else
                spawnPoint = AdjustSpawnPoint(Random.Range(Xmin.x, Ymax.x), Ymax.y + 2);
        }

        return spawnPoint;
    }
    
    public Vector3 AdjustSpawnPoint(float x, float y)
    {
        return new Vector3(x,y,1);
    }
}
