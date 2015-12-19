using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

    public bool autoPlay = false;

    private Ball ball;
    private float xBallMinusPaddle;

    void Start ()
    {
        ball = GameObject.FindObjectOfType<Ball>();

        // Find initial difference between ball and paddle's x position, so we can maintain it on autoPlay
        xBallMinusPaddle = ball.transform.position.x - this.transform.position.x;
    }

	// Update is called once per frame
	void Update () {
        if (autoPlay)
        {
            AutoPlay();
        } else
        {
            MoveWithMouse();
        }
    }

    void AutoPlay()
    {
        float ballPos = ball.transform.position.x;
        float newPaddlePos = Mathf.Clamp(ballPos - xBallMinusPaddle, 0f, 15f);
        this.transform.position = new Vector3(newPaddlePos, this.transform.position.y);
    }

    void MoveWithMouse()
    {
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
        mousePosInBlocks = Mathf.Clamp(mousePosInBlocks, 0f, 15f);
        this.transform.position = new Vector3(mousePosInBlocks, this.transform.position.y);
    }
}
