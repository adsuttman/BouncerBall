using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    CanvasGroup canvas;
    private void Start()
    {

    }

    public void Hide()
    {
        if (canvas == null) GetCanvasGroup();
        canvas.alpha = 0;
        canvas.interactable = false;
    }
    public void Show()
    {
        if (canvas == null) GetCanvasGroup();
        canvas.alpha = 1;
        canvas.interactable = true;
    }

    public void SetScoreText(string score)
    {
        scoreText.text = score;
    }
    public void GetCanvasGroup()
    {
        canvas = gameObject.GetComponent<CanvasGroup>();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Return()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
