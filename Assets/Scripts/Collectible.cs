using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Collectible : MonoBehaviour
{
    new Collider2D collider;
    public LayerMask ballLayer;
    public GameObject[] spawnedObjects;
    public event Action collected;

    // Start is called before the first frame update
    void Start()
    {
        collider = gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (collider.IsTouchingLayers(ballLayer))
        {
            onBallCollision();
        }
    }
    void onBallCollision()
    {
        print("collected");
        collected();
        GameObject inst = Instantiate(GetSpawnable());
        inst.transform.position = transform.position;
        Destroy(gameObject);
    }
    GameObject GetSpawnable()
    {
        return spawnedObjects[Random.Range(0, spawnedObjects.Length)];
    }
}
