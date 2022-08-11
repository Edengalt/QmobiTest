using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : DeathBehaviour
{

    [SerializeField] private GameObject shield;
    public override void Rollout()
    {
        UIController.GetInstance().Loose();
        UIController.GetInstance().ReduceLife();
        GetComponent<PlayerMovement>().Kill();
    }

    public override void Roll()
    {
        base.Roll();
        GetComponent<PlayerMovement>().Resurrect();
        SetupShield();
    }

    public override void GetDamage()
    {
        base.GetDamage();
        UIController.GetInstance().ReduceLife();
        SetupShield();
    }

    public void SetupShield()
    {
        shield.SetActive(true);
        collider.enabled = false;
        StartCoroutine(Delay());
    }

    public IEnumerator Delay()
    {
        yield return new WaitForSecondsRealtime(2);
        collider.enabled = true;
        shield.SetActive(false);
    }

    public override void OnCollision(GameObject go)
    {
        Death();
    }

    
}
