using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrdinaryAsteroid : AsteroidBehaviour
{
    public override void DestroyAsteroid()
    {
        foreach (var asteroid in smallerAsteroids)
        {
            asteroid.Init(pool,transform.position,direction);
        }
        base.DestroyAsteroid();
    }
}
