﻿using UnityEngine;

public class AsteroidBall : MonoBehaviour
{

    private Paddle paddle;
    private Vector3 paddleToBallVector;

    public bool hasStarted = false;

    // Use this for initialization
    void Start()
    {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = (this.transform.position - paddle.transform.position);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 increaseInVelocity = new Vector2(Random.Range(0f, 0.2f), (Random.Range(0f, 0.2f)));

        if (hasStarted == true)
        {
            GetComponent<AudioSource>().Play();
            GetComponent<Rigidbody2D>().velocity += increaseInVelocity;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //Locking the ball position
        if (!hasStarted)
        {
            this.transform.position = paddle.transform.position + paddleToBallVector;
            // Wait for mouse press
            if (Input.GetMouseButtonDown(0))
            {
                hasStarted = true;
                Debug.Log("Mouse Clicked and Ball is Launched");
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
            }
        }

    }
}
