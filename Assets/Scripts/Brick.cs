using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

    public static int ActiveBreakableBlocks = 0;

    public Sprite[] HitSprite;
	public AudioClip audioClip;
	public float explosionPower;
	
	private int MaxHits;
    private int TimesHit = 0;
    private bool isBreakable;
    private SpriteRenderer spriteRenderer;
    private LevelManager levelManager;

	public GameObject explosion;

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
            HandleHits(collission);
        }
    }

	void HandleHits(Collision2D collission)
	{
        AudioSource.PlayClipAtPoint(audioClip, transform.position);
        TimesHit++;
        if (TimesHit >= MaxHits)
        {
			Instantiate(explosion, this.transform.position, Quaternion.identity);
			Explode (collission);
			Destroy(gameObject);
			ActiveBreakableBlocks--;
			levelManager.BrickDestroyed();
		}
		else
		{
            LoadSprite();
        }
    }

	void Explode(Collision2D collission) {
		Vector3 explosionPos = transform.position;
		Rigidbody2D rb = collission.collider.GetComponent<Rigidbody2D> ();
			
		if (rb != null) {
			Vector2 explosionForce = new Vector2(1/rb.transform.position.x, 1/rb.transform.position.y) * explosionPower;
			rb.AddForceAtPosition(explosionForce, explosionPos);
			Debug.Log ("Explosion of " + explosionForce + " applied to " + rb.name + " at " + explosionPos);
		}
	}
		
		void LoadSprite()
		{
			int spriteIndex = TimesHit - 1;
			if (HitSprite[spriteIndex])
            spriteRenderer.sprite = HitSprite[spriteIndex];
    }
}
