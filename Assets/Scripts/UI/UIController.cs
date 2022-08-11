using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIController : MonoBehaviour
{

    #region singleton

    private static UIController Instance;
    public static UIController GetInstance()
    {
        return Instance;
    }

   

    #endregion
    

    [SerializeField] private ScoreCounter scoreCounter;
    [SerializeField] private GameObject LoosePanel;
    [SerializeField] private GameObject lifePrefab;
    [SerializeField] private Transform lifePanel;
    [SerializeField] private DeathBehaviour player;
    public DeathBehaviour PlayerLink => player;
    
    private List<GameObject> lifes = new List<GameObject>();
    private List<GameObject> lostLifes = new List<GameObject>();
    private void Start()
    {
        Instance = this;
        for (int i = 0; i < player.amountOfLives; i++)
        {
            GameObject newL = Instantiate(lifePrefab, lifePanel);
            lifes.Add(newL);
            newL.SetActive(true);
        }
    }

    public void ReduceLife()
    {
        if(lifes.Count == 0 ) return;
        GameObject l = lifes[^1];
        lifes.Remove(l);
        lostLifes.Add(l);
        l.SetActive(false);
    }

    public void UpdateScore(int additionalScore)
    {
        scoreCounter.UpdateScore(additionalScore);
    }

    public void Loose()
    {
        StartCoroutine(Delay());
    }
    
    public IEnumerator Delay()
    {
        yield return new WaitForSecondsRealtime(3);
        LoosePanel.SetActive(true);
    }
    
    public void Restart()
    {
        foreach (var lostLife in lostLifes)
        {
            lifes.Add(lostLife);
            lostLife.SetActive(true);
        }
        lostLifes.Clear();
        scoreCounter.ResetScore();
    }

    public void Exit()
    {
        Application.Quit();
    }
}
