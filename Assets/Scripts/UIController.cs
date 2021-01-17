using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameOverPopup gameOverPopup;
    [SerializeField] private Text scoreText;

    public void Init()
    {
        UpdateScore(0);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void ShowResultPopup(int score, int bestScore)
    {
        gameOverPopup.Show(score, bestScore);
    }
}
