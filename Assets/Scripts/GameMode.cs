using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    public bool loseable = false;
    public bool spawnCollectibles = false;
    public Collectible collectible;
    public float minSpawnX = -8f;
    public float maxSpawnX = 8f;
    public float minSpawnY = -2f;
    public float maxSpawnY = 4f;
    public Ball ball;
    // Start is called before the first frame update
    void Start()
    {
        Floor.OnFloorCollided += Floor_OnFloorCollided;
        Pointer.AllBallsDisabled += Pointer_AllBallsDisabled;
        SpawnCollectible();
        SpawnBall(Vector3.zero);
        
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
        print("Game Over");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(new Vector3((maxSpawnX + minSpawnX)/2, (maxSpawnY + minSpawnY)/2), new Vector3(maxSpawnX-minSpawnX, maxSpawnY-minSpawnY));
    }
}
