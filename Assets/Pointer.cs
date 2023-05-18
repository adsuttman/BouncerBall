using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    GameObject obj;
    public GameObject[] balls;
    float shoveForce = 100;
    float shoveDelay = 15;
    float shoveTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //sets position of pointer to position of mouse
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        obj.transform.position = Camera.main.ScreenToWorldPoint(mousePos);


        if (Input.GetButtonDown("Fire1") && shoveTimer <= 0)
        {
            foreach (GameObject ball in balls)
            {
                Vector3 direction = ball.transform.position - obj.transform.position;
                float distance = direction.magnitude;
                if (distance < 10)
                {
                    ball.GetComponent<Rigidbody2D>().AddForce(direction.normalized * shoveForce, ForceMode2D.Impulse);
                }
            }
            shoveTimer = shoveDelay;
        }
        shoveTimer -= 1;
    }

}
