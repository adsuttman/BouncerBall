using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreFrenzyMode : ScoreMode
{
    public int bonusInterval = 5;
    bool bonusEnabled = false;
    IEnumerator timer;

    public override void OnCollected()
    {
        base.OnCollected();
        if (!bonusEnabled)
        {
            timer = BonusTimer();
            StartCoroutine(timer);
            bonusEnabled = true;
        }

    }

    public override void GameOver()
    {
        base.GameOver();
        StopCoroutine(timer);
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
