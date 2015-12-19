using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
    public float RandomnessFactor;

    private Paddle paddle;
    private Vector3 paddleToBallVector;
    private bool Launched = false;
    private Rigidbody2D rb;

    private static Vector2 INITIAL_VELOCITY = new Vector2(3f, 8f);

    // Use this for initialization
    void Start ()
    {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
        rb = this.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!Launched)
        {
            // Lock the ball to the paddle
            this.transform.position = paddle.transform.position + paddleToBallVector;

            // Wait for mouse press to launch
            if (Input.GetButtonDown("Fire1"))
            {
                Launched = true;
                rb.velocity = INITIAL_VELOCITY;
            }
        }
	
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(0f, RandomnessFactor), Random.Range(0f, RandomnessFactor));

        if (Launched)
        {
            GetComponent<AudioSource>().Play();
            rb.velocity += tweak;
        }
    }
}
