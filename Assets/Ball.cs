using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject pointer = GameObject.Find("Pointer");
        Pointer script = pointer.GetComponent<Pointer>();
        ArrayUtility.Add<GameObject>(ref script.balls, gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
