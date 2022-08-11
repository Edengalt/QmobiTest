using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiggestAsteroid : AsteroidBehaviour
{
    public override void DestroyAsteroid()
    {
        foreach (var asteroid in smallerAsteroids)
        {
            asteroid.Init(pool,transform.position,direction);
        }
        pool.ReturnToPool(this);
        base.DestroyAsteroid();
    }

    
}
