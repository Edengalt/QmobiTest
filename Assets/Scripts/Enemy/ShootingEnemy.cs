using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MovableUpdatedEnemy
{

    private Transform target;
    [SerializeField] private int shootDelay = 1;
    [SerializeField]private GameObject siren;
    private float shootDelayCounter = 1;
    private BulletPool Bpool;

    private EnemyManager EManager;
    public override void Awakening()
    {
        base.Awakening();
        Bpool =  BulletPool.GetInstance();
        shootDelayCounter = shootDelay;
        target = UIController.GetInstance().PlayerLink.transform;
    }
    
    public void Init(EnemyManager _EManager, Vector3 startPos, Vector3 dir)
    {
        EManager = _EManager;
        dead = false;
        Resurrect();
        pathf = 0;
        center = new Vector3(dir.x,dir.y,1);
        transform.position = startPos + new Vector3(RandValueSmall,RandValueSmall,0);
        direction = (center - transform.position + new Vector3(RandValueBig,RandValueBig,0)).normalized;
        
    }

    public override void Move()
    {
        if(dead) return;
        base.Move();
        
        shootDelayCounter -= Time.deltaTime;
        if (shootDelayCounter <= 0)
        {
            Bpool.GetBullet("Enemy").Shoot(transform.position, (target.position - transform.position).normalized);
            shootDelayCounter = shootDelay;
        }
    }

    public override void Rollout()
    {
        dead = true;
        EManager.CanBeSpawned();
        siren.SetActive(false);
        pathf = 0;
        direction = Vector3.zero;
        StartCoroutine(Delay());
    }
    public IEnumerator Delay()
    {
        yield return new WaitForSecondsRealtime(2);
        Destroy(gameObject);
    }

}
