using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerMode : GameMode
{
    int score = -1;
    IEnumerator timer;

    public override void Ball_Activated()
    {
        base.Ball_Activated();
        timer = ScoreTimer();
        StartCoroutine(timer);

    }
    public override void GameOver()
    {
        StopCoroutine(timer);
        gameOverCanvas.SetScoreText("You lasted for " + score + " seconds");
        base.GameOver();
    }

    IEnumerator ScoreTimer()
    {
        for (; ; )
        {
            score++;
            scoreDisplay.SetScoreText(score + " s");
            yield return new WaitForSeconds(1);
        }
        
    }
}
