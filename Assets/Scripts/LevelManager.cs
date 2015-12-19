using UnityEngine;
using UnityEditor;
using System;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name)
    {
        Debug.Log("Loading Level: '" + name + "'");
        Brick.ActiveBreakableBlocks = 0;
        Application.LoadLevel(name);
    }

    public void QuitRequest()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        Brick.ActiveBreakableBlocks = 0;
        Application.LoadLevel(Application.loadedLevel + 1);
    }

    public void BrickDestroyed()
    {
        if (Brick.ActiveBreakableBlocks <= 0)
        {
            LoadNextLevel();
        }
    }
}
