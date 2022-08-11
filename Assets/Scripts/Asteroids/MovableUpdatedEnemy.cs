using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovableUpdatedEnemy : MovableNonEnemyBase
{
    
    protected float pathf = 0;
    [SerializeField] protected int maxPath = 20;
    
    protected Vector3 center = new Vector3(0,0,1);
    protected float RandValueSmall => Random.Range(-0.4f, 0.4f);
    protected float RandValueBig => Random.Range(-4f, 4f);
    void Update()
    {
        Move();
    }

    public override void Move()
    {
        transform.position += direction * Time.deltaTime * speed;
        pathf += (direction * Time.deltaTime).magnitude;
        if (pathf > maxPath)
        {
            pathf = 0;
            direction = Vector3.zero;
            Rollout();
        }
    }

    public override void OnCollision(GameObject go) { }

}
