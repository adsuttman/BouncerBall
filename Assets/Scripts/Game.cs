using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public bool loseable = false;
    // Start is called before the first frame update
    void Start()
    {
        Floor.OnFloorCollided += Floor_OnFloorCollided;
        
    }

    private void Floor_OnFloorCollided(GameObject obj)
    {
        if (loseable) {
            obj.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
