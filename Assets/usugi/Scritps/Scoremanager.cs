using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static float Score {  get; private set; }

    private void Awake()
    {
        ResetScore();
    }

    public void AddScore(float score)
    {
        Score += score;
    }

    private void ResetScore()
    {
        Score = 0;
    }
}
