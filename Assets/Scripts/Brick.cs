using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

    public static int ActiveBreakableBlocks = 0;

    public Sprite[] HitSprite;
    public AudioClip audioClip;

    private int MaxHits;
    private int TimesHit = 0;
    private bool isBreakable;
    private SpriteRenderer spriteRenderer;
    private LevelManager levelManager;

    void Awake () {
        isBreakable = (this.tag == "Breakable");
        if (isBreakable)
        {
            ActiveBreakableBlocks++;
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        MaxHits = HitSprite.Length + 1;
    }

    void OnCollisionExit2D(Collision2D collission)
    {
        if (isBreakable) {
            HandleHits();
        }
    }

    void HandleHits()
    {
        AudioSource.PlayClipAtPoint(audioClip, transform.position);
        TimesHit++;
        if (TimesHit >= MaxHits)
        {
            Destroy(gameObject);
            ActiveBreakableBlocks--;
            levelManager.BrickDestroyed();
        }
        else
        {
            LoadSprite();
        }
    }

    void LoadSprite()
    {
        int spriteIndex = TimesHit - 1;
        if (HitSprite[spriteIndex])
            spriteRenderer.sprite = HitSprite[spriteIndex];
    }
}
