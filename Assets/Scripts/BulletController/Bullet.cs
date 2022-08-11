using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : BulletBase
{
    private Vector3 direction = Vector3.zero;

    public void Shoot(Vector3 startPos ,Vector3 _direction)
    {
        gameObject.SetActive(true);
        transform.SetParent(transform.parent);
        transform.position = startPos;
        direction = _direction;
    }

    private void Update()
    {
        Move();
    }

    
    
    public override void Collision()
    {
        gameObject.SetActive(false);
        ResetBullet();
    }

    public override void Move()
    {
        transform.position += direction * Time.deltaTime * Speed;
        pathf += (direction * Time.deltaTime).magnitude;
        if (pathf > maxPath)
        {
            ResetBullet();
        }
    }

    public void ResetBullet()
    {
        TR.Clear();
        pathf = 0;
        direction = Vector3.zero;
        gameObject.SetActive(false);
        pool.ReturnBullet(this);
    }

    public override void OnTrigger(Collider other)
    {
        if (other.CompareTag(tag)) return;
        ResetBullet();
    }
}
