using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBorad : MonoBehaviour
{
    [SerializeField] int scorePerSecond = 75;

    int score;
    Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString("00000");
    }

    public void ScoreHit(int Score)
    {
        score = score + Score;
        scoreText.text = score.ToString("00000");
    }
}
