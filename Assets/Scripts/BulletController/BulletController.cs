using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletController : MonoBehaviour
{
     private BulletPool bulletPool;
    private AudioStarter audio;

    private void Start()
    {
        bulletPool = BulletPool.GetInstance();
        audio = GetComponent<AudioStarter>();
        this.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            bulletPool.GetBullet("Player").Shoot(transform.position, transform.up);
            audio.Play();
        }
    }
}
