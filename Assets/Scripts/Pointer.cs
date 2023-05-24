using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pointer : MonoBehaviour
{
    GameObject obj;
    public GameObject[] balls;
    public float shoveForce = 10;
    public float shoveDelay = 15;
    float shoveTimer = 0;
    public LayerMask shoveLayer;
    public Image charge;
    public float maxSpeedpoints = 100;
    float speedpoints;
    public Color positive;
    public Color negative;

    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        speedpoints = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //sets position of pointer to position of mouse
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 newPos = Camera.main.ScreenToWorldPoint(mousePos);
        newPos.z = 0;
        obj.transform.position = newPos;


        if (Input.GetButtonDown("Fire1") && shoveTimer == 0)
        {
            foreach (GameObject ball in balls)
            {
                Vector3 direction = ball.transform.position - obj.transform.position;
                /*                float distance = direction.magnitude;
                */
                Rigidbody2D rigid = ball.GetComponent<Rigidbody2D>();
                if (rigid.IsTouchingLayers(shoveLayer))
                {
                    rigid.AddForce(direction.normalized * shoveForce, ForceMode2D.Impulse);
                    shoveTimer = shoveDelay;

                }
            }
        }
        if (Input.GetButtonDown("Fire2"))
        {
            foreach (GameObject ball in balls)
            {
                Rigidbody2D rigid = ball.GetComponent<Rigidbody2D>();
                if (rigid.IsTouchingLayers(shoveLayer) && speedpoints == maxSpeedpoints)
                {
                    rigid.velocity = Vector2.zero;
                    rigid.angularVelocity = 0;
                    UpdateSpeedpoints(0);

                }
            }
        }
        if (shoveTimer > 0) shoveTimer--;
    }
    void FixedUpdate()
    {
        foreach (GameObject ballObj in balls)
        {
            Ball ball = ballObj.GetComponent<Ball>();
            if (ball.speeding)
            {
                UpdateSpeedpoints(speedpoints + 1);
            }
        }
    }

    void UpdateCharge()
    {
        charge.fillAmount = speedpoints/maxSpeedpoints;
        if (speedpoints == maxSpeedpoints) {
            charge.color = positive;
        } else
        {
            charge.color = negative;
        }
    }

    void UpdateSpeedpoints(float points)
    {
        if (speedpoints == maxSpeedpoints && points != 0)
        {
            return;
        }
        speedpoints = points;
        Mathf.Clamp(speedpoints, 0, maxSpeedpoints);
        UpdateCharge();
    }
}
