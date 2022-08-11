using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public abstract class AsteroidBehaviour : MovableUpdatedEnemy
{
    [SerializeField] protected List<AsteroidBehaviour> smallerAsteroids = new List<AsteroidBehaviour>();
    [SerializeField] protected AsteroidBehaviour prefab;
    [SerializeField] protected int achivableScore = 0;
    protected AsteroidsManager pool;

    public override void Awakening()
    {
        base.Awakening();
        if(prefab == null) return;
        for (int i = 0; i < Random.Range(1f,3f); i++)
        {
            AsteroidBehaviour Smol = Instantiate(prefab, transform.parent);
            Smol.gameObject.SetActive(false);
            smallerAsteroids.Add(Smol);
        }
    }

    public void Init(AsteroidsManager _pool, Vector3 startPos, Vector3 dir)
    {
        Resurrect();
        pool = _pool; 
        pathf = 0;
        center = new Vector3(dir.x,dir.y,1);
        transform.position = startPos + new Vector3(RandValueSmall,RandValueSmall,0);
        direction = (center - transform.position + new Vector3(RandValueBig,RandValueBig,0)).normalized;
        
    }
    public override void Rollout()
    {
        DestroyAsteroid();
        UIController.GetInstance().UpdateScore(achivableScore);
    }

    public override void Move() 
    {
        base.Move();
        if (pathf > maxPath)
        {
            pool.ResetAsteroid(this);
        }
    }

    
    public virtual void DestroyAsteroid()
    {
        pathf = 0;
        direction = Vector3.zero;
        //Death();
    }
    
    public override void DelayedRollout()
    {
        pool.ResetAsteroid(this);
    }
}
