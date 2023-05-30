using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreFrenzyMode : ScoreMode
{
    public int bonusInterval = 5;
    bool bonusEnabled = false;
    IEnumerator timer;

    public override void Ball_Activated()
    {
        base.Ball_Activated();
        if (!bonusEnabled)
        {
            timer = BonusTimer();
            StartCoroutine(timer);
            bonusEnabled = true;
        }

    }

    public override void GameOver()
    {
        if (timer != null) StopCoroutine(timer);
        base.GameOver();
    }
    IEnumerator BonusTimer()
    {
        for(; ; )
        {
            print("Bonus Spawn");
            base.SpawnCollectible();
            yield return new WaitForSeconds(bonusInterval);
        }
        
    }

}
