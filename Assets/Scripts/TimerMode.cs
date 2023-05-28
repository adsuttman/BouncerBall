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
        base.GameOver();
        StopCoroutine(timer);
        print("You lasted for " + score + " seconds");
    }

    IEnumerator ScoreTimer()
    {
        for (; ; )
        {
            score++;
            yield return new WaitForSeconds(1);
        }
        
    }
}
