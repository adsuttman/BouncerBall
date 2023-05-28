using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    Pointer script;
    public Rigidbody2D rigid;
    public bool speeding = false;
    public ParticleSystem particles;
    public float speedingFactor = 300;
    public static event Action Activated;
    void Start()
    {
        GameObject pointer = GameObject.Find("Pointer");
        script = pointer.GetComponent<Pointer>();
        ArrayUtility.Add(ref script.balls, this);

        rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnDisable()
    {
        script.CheckBalls();
    }
    void FixedUpdate()
    {
        float speed = rigid.velocity.sqrMagnitude / speedingFactor;
        speeding = speed > 1;
        if (speeding)
        {
            particles.Emit(Mathf.FloorToInt(speed));
        }
    }
    public void Activate()
    {
        if (!rigid.simulated)
        {
            rigid.simulated = true;
            Activated();
        }
    }
}
