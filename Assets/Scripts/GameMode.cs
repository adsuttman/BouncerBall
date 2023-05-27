using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    public bool loseable = false;
    public bool spawnCollectibles = false;
    public Collectible collectible;
    public float minSpawnX = -8.5f;
    public float maxSpawnX = 8.5f;
    public float minSpawnY = -4.5f;
    public float maxSpawnY = 4.5f;
    // Start is called before the first frame update
    void Start()
    {
        Floor.OnFloorCollided += Floor_OnFloorCollided;
        Pointer.AllBallsDisabled += Pointer_AllBallsDisabled;
        SpawnCollectible();
        
    }

    private void Pointer_AllBallsDisabled()
    {
        print("Game Over");
    }

    private void Floor_OnFloorCollided(GameObject obj)
    {
        if (loseable) {
            obj.SetActive(false);
        }
    }

    void SpawnCollectible()
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
    void OnCollected()
    {
        if (spawnCollectibles)
        {
            SpawnCollectible();
        }
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
