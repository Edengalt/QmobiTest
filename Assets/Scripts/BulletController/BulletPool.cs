using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    
    #region singleton
    private static BulletPool Instance;
    public static BulletPool GetInstance()
    {
        return Instance;
    }
    private void OnEnable()
    {
        Instance = this;
    }
    #endregion
    
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField][Range(1,100)] private int bulletAmount;
    
    private List<Bullet> pool = new List<Bullet>();

    

    private void Start()
    {
        for (int i = 0; i < bulletAmount; i++)
        {
            Bullet singleBullet = Instantiate(bulletPrefab, transform);
            singleBullet.Init(this);
            pool.Add(singleBullet);
            singleBullet.gameObject.SetActive(false);
        }
    }

    public Bullet GetBullet(string starter)
    {
        Bullet toExit;
        if (pool.Count == 0)
        {
            toExit = Instantiate(bulletPrefab, transform);
            toExit.Init(this);
            toExit.gameObject.SetActive(false);
        }
        else
        {
            toExit = pool[pool.Count-1];
            pool.Remove(toExit);
        }

        toExit.SetupStarter(starter);
        return toExit;
    }
    
    

    public void ReturnBullet(Bullet toPool)
    {
        pool.Add(toPool);
        toPool.transform.SetParent(transform);
        toPool.transform.position = Vector3.zero;
    }
}
