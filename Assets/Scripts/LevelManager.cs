using UnityEngine;
using UnityEditor;
using System;

public class LevelManager : MonoBehaviour {

	public bool DebugMode;

	public void Start() {
		if (DebugMode) {
			SetDebugMode ();
		}
	}

	public void LoadLevel(string name)
    {
        Debug.Log("Loading Level: '" + name + "'");
		Application.LoadLevel(name);
		Brick.ActiveBreakableBlocks = 0;
	}
	
	public void QuitRequest()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }

    public void LoadNextLevel()
	{
		Debug.Log("Loading next level");
		Application.LoadLevel(Application.loadedLevel + 1);
		Brick.ActiveBreakableBlocks = 0;
	}
	
	public void BrickDestroyed()
    {
		Debug.Log ("Brick destroyed, bricks left: " + Brick.ActiveBreakableBlocks);
        if (Brick.ActiveBreakableBlocks <= 0)
        {
            LoadNextLevel();
        }
    }

	private void SetDebugMode() {
		Ball ball = FindObjectOfType<Ball> ();
		Paddle paddle = FindObjectOfType<Paddle> ();

		if (ball)
			ball.autoPlay = true;
		if (paddle)
			paddle.autoPlay = true;
	}
}
