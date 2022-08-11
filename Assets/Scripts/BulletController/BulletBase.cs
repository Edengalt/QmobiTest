using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletBase : CollisiableMono, IMovable
{
    [SerializeField] protected int Speed;
    [SerializeField] protected int maxPath = 100;
    protected float pathf = 0;
    protected BulletPool pool;
    protected TrailRenderer TR;
   // private string starter;
    
    public void Init(BulletPool _pool)
    {
        pool = _pool;
        TR = GetComponent<TrailRenderer>();
    }
    
    public void SetupStarter(string name)
    {
        tag = name;
    }

    public override void OnCollision(GameObject go) { }

    public abstract void Collision();
    public abstract void Move();
}
