using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    new Collider2D collider;
    public LayerMask ballLayer;
    public GameObject effectArea;

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
        GameObject inst = Instantiate(effectArea);
        inst.transform.position = transform.position;
        Destroy(gameObject);
    }
}
