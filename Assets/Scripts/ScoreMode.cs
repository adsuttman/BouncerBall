using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreMode : GameMode
{
    int score = 0;

     override public void GameOver()
    {
        print("You got a score of " + score);
    }
    override public void OnCollected()
    {
        base.OnCollected();
        score += 1;
    }
}
