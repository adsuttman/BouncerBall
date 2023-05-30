using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMode : MonoBehaviour
{
    public bool loseable = false;
    public bool spawnCollectibles = false;
    public Ball ball;
    public GameOver gameOverCanvas;
    public GameObject pointer;
    public ScoreDisplay scoreDisplay;
    public CanvasGroup tutorialText;
    [Header("Collectible Settings")]
    public Collectible collectible;
    public float minSpawnX = -8f;
    public float maxSpawnX = 8f;
    public float minSpawnY = -2f;
    public float maxSpawnY = 4f;
    // Start is called before the first frame update
    void Start()
    {
        Floor.OnFloorCollided += Floor_OnFloorCollided;
        Pointer.AllBallsDisabled += Pointer_AllBallsDisabled;
        Ball.Activated += Ball_Activated;
        SpawnCollectible();
        SpawnBall(Vector3.zero);
        
    }
    private void OnDestroy()
    {
        Floor.OnFloorCollided -= Floor_OnFloorCollided;
        Pointer.AllBallsDisabled -= Pointer_AllBallsDisabled;
        Ball.Activated -= Ball_Activated;
    }

    public virtual void Ball_Activated()
    {
        print("Ball Activated");
        scoreDisplay.Show();
        tutorialText.alpha = 0;
    }

    private void Pointer_AllBallsDisabled()
    {
        GameOver();
    }

    private void Floor_OnFloorCollided(GameObject obj)
    {
        if (loseable) {
            obj.SetActive(false);
        }
    }

    protected void SpawnCollectible()
    {
        if (spawnCollectibles)
        {
            float randx = Random.Range(minSpawnX, maxSpawnX);
            float randy = Random.Range(minSpawnY, maxSpawnY);
            Collectible inst = Instantiate(collectible);
            inst.collected += OnCollected;
            inst.transform.position = new Vector3(randx, randy);
        }
    }
    void SpawnBall(Vector3 spawnPosition, bool serving = true)
    {
        Ball inst = Instantiate(ball);
        inst.transform.position = spawnPosition;
        if (!serving)
        {
            inst.GetComponent<Rigidbody2D>().simulated = true;
        }

    }
    virtual public void OnCollected()
    {
        if (spawnCollectibles)
        {
            SpawnCollectible();
        }
    }

    virtual public void GameOver()
    {
        pointer.SetActive(false);
        scoreDisplay.Hide();
        if (gameOverCanvas != null)
        {
            gameOverCanvas.Show();
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            ReloadScene();
        }
        if (Input.GetButton("Cancel"))
        {
            ReturnToMainMenu();
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(new Vector3((maxSpawnX + minSpawnX)/2, (maxSpawnY + minSpawnY)/2), new Vector3(maxSpawnX-minSpawnX, maxSpawnY-minSpawnY));
    }
}
