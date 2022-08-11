using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class DeathBehaviour : CollisiableMono
{
    protected ParticleSystem PS;
    protected AudioStarter audio;
    protected Image img;
    protected Rigidbody rigid;
    protected bool dead = false;
    public int amountOfLives = 1;
    private int amountOfLivesCounter;

   

    public override void Awakening()
    {
        amountOfLivesCounter = amountOfLives;
        audio = GetComponent<AudioStarter>();
        PS = GetComponentInChildren<ParticleSystem>();
        img = GetComponent<Image>();
        rigid = GetComponent<Rigidbody>();
    }

    public void Death()
    {
        amountOfLivesCounter--;
        if(amountOfLivesCounter == 0)
        {
            dead = true;
            rigid.isKinematic = true;
            img.enabled = false;
            collider.enabled = false;
            audio.Play();
            PS.Play();
            StartCoroutine(Delay());
            Rollout();
        }
        else
        {
            GetDamage();
        }
        
        
    }
    
    public virtual void GetDamage() { }
    
    public void Resurrect()
    {
        dead = false;
        amountOfLivesCounter = amountOfLives;
        rigid.isKinematic = false;
        img.enabled = true;
        collider.enabled = true;
        img.enabled = true;
        gameObject.SetActive(true);
        Roll();
    }
    
    
    public virtual void Roll() { }
    public abstract void Rollout();
    public IEnumerator Delay()
    {
        yield return new WaitForSecondsRealtime(2);
        DelayedRollout();
    }
    
    public override void OnTrigger(Collider other)
    {
        if(other.CompareTag(tag)) return;
        Death();
    }

    public virtual void DelayedRollout() { }
   
}
