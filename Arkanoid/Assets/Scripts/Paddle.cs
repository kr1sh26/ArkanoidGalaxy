using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private AsteroidBall asteroidBall;

    public bool autoPlay = false;

    void Start()
    {
        asteroidBall = GameObject.FindObjectOfType<AsteroidBall>();
    }

    void Update()
    {
        if (!autoPlay)
        {
            MoveWithMouse();
        }
        else
        {
            AutoPlay();
        }

    }

    void AutoPlay()
    {
        Vector3 paddlePos = new Vector3(0.869f, transform.position.y, 0f);
        Vector3 ballPos = asteroidBall.transform.position;
        paddlePos.x = Mathf.Clamp(ballPos.x, 1.14f, 14.8f);
        this.transform.position = paddlePos;
    }

    void MoveWithMouse()
    {
        Vector3 paddlePos = new Vector3(0.869f, transform.position.y, 0f);
        float mousePosInBlocks = (Input.mousePosition.x / Screen.width * 16);
        paddlePos.x = Mathf.Clamp(mousePosInBlocks, 1.14f, 14.8f);
        this.transform.position = paddlePos;
    }
}
