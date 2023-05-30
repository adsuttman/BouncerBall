using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreMode : GameMode
{
    int score = 0;

     override public void GameOver()
    {
        gameOverCanvas.SetScoreText("You got a score of " +  score);
        base.GameOver();
    }
    override public void OnCollected()
    {
        base.OnCollected();
        score += 1;
    }
}
