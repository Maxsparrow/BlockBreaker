using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
    public float RandomnessFactor;
	public Vector2 InitialVelocity;
	public float RotationSpeed;
	public bool autoPlay;

    private Paddle paddle;
    private Vector3 paddleToBallVector;
    private bool Launched = false;
    private Rigidbody2D rb;

	private static Vector2 AUTOPLAY_VELOCITY = new Vector2(6f, 16f);

    // Use this for initialization
    void Start ()
    {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
        rb = this.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Launched) {
			rb.transform.Rotate (new Vector3(0, 0, RotationSpeed));
		}
		else if (!Launched)
        {
            // Lock the ball to the paddle
            this.transform.position = paddle.transform.position + paddleToBallVector;

            // Wait for mouse press to launch
			if (autoPlay || Input.GetButtonDown("Fire1"))
            {
                Launched = true;
				rb.velocity = autoPlay? AUTOPLAY_VELOCITY : InitialVelocity;
            }
        }
	
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
		Vector2 tweak = new Vector2(Random.Range(0, RandomnessFactor), Random.Range(0, RandomnessFactor));

        if (Launched)
        {
            GetComponent<AudioSource>().Play();
            rb.velocity += tweak;
        }
    }
}
