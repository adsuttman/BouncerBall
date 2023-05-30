using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    CanvasGroup canvasGroup;
    public TextMeshProUGUI scoreText;
    void Start()
    {
        GetCanvasGroup();
    }

    public void Show()
    {
        canvasGroup.alpha = 1;
    }
    public void Hide()
    {
        canvasGroup.alpha = 0;
    }

    void GetCanvasGroup()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void SetScoreText(string text)
    {
        scoreText.text = text;
    }
}
