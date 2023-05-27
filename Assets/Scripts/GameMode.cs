using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    public bool loseable = false;
    // Start is called before the first frame update
    void Start()
    {
        Floor.OnFloorCollided += Floor_OnFloorCollided;
        Pointer.AllBallsDisabled += Pointer_AllBallsDisabled;
        
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
