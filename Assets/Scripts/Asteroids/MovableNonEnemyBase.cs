using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovableNonEnemyBase : DeathBehaviour
{
    public float speed;
    protected Vector3 direction = Vector3.zero;
    public abstract void Move();
    
    
}
