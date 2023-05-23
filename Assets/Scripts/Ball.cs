using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    Pointer script;
    Rigidbody2D rigid;
    bool speeding = false;
    void Start()
    {
        GameObject pointer = GameObject.Find("Pointer");
        script = pointer.GetComponent<Pointer>();
        ArrayUtility.Add<GameObject>(ref script.balls, gameObject);

        rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = rigid.velocity.sqrMagnitude / 200;
        print(speed);
        speeding = speed > 1;
    }
}
