using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollisiableMono : MonoBehaviour, ICollisiable
{

    protected Collider collider;
    
    private void Awake()
    {
        collider = collider = GetComponent<Collider>();
        Awakening();
    }

    public virtual void Awakening(){}
    private void OnTriggerEnter(Collider other)
    {
        OnTrigger(other);
    }

    private void OnCollisionEnter(Collision other)
    {
        OnCollision(other.gameObject);
    }

    
    public abstract void OnCollision(GameObject go);

    public abstract void OnTrigger(Collider other);
}
