using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private TextMeshProUGUI text;
    private int score = 0;
    
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = score.ToString();
    }

    public void UpdateScore(int additionalScore)
    {
        score += additionalScore;
        text.text = score.ToString();
    }

    public void ResetScore()
    {
        score = 0;
        text.text = score.ToString();
    }

}
