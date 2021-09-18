using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public void Start()
    {
        UpdateScore(0);
    }
    public void UpdateScore(int add)
    {
        score += add;
        scoreText.text = $"Score: {score}";
    }
}
