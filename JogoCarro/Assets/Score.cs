using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Score : MonoBehaviour
{
    public static Score Instance;

    [SerializeField] private TextMeshProUGUI currentScoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    private int score;

    private void Awake()
    {
        if (Instance == null) 
        {
            Instance = this;
        }
    }

    private void Start()
    {
        currentScoreText.text = score.ToString();

        highScoreText.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
        UpdateHighScore();
    }

    private void UpdateHighScore() 
    {
        if (score > PlayerPrefs.GetInt("Highscore")) 
        {
            PlayerPrefs.SetInt("Highscore", score);
            highScoreText.text = score.ToString();
        }
    }

    public void UpdateScore() 
    {
        score++;
        currentScoreText.text = score.ToString();
        UpdateHighScore();
    }
}
