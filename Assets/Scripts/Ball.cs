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
    public bool speeding = false;
    public ParticleSystem particles;
    void Start()
    {
        GameObject pointer = GameObject.Find("Pointer");
        script = pointer.GetComponent<Pointer>();
        ArrayUtility.Add<GameObject>(ref script.balls, gameObject);

        rigid = gameObject.GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        float speed = rigid.velocity.sqrMagnitude / 200;
        speeding = speed > 1;
        if (speeding)
        {
            particles.Emit(Mathf.FloorToInt(speed));
        }
    }
}
