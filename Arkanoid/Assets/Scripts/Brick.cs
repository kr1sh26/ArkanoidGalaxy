using UnityEngine;
using UnityEngine.SceneManagement;
using System.Configuration;

public class Brick : MonoBehaviour
{
    private int timesHit;
    private bool isBreakable;

    public LevelManager levelManager;
    public AudioClip brickBreakSound;
    public Sprite[] hitSprites;
    public static int breakableCount = 0;
    public GameObject smoke;

    int ScoreValue = 50;

    // Use this for initialization
    void Start()
    {
        isBreakable = (this.tag == "Breakable");

        //keeping track of breakable bricks
        if (isBreakable)
        {
            breakableCount++;
            print(breakableCount);
        }
        timesHit = 0;
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        AudioSource.PlayClipAtPoint(brickBreakSound, transform.position);
        if (isBreakable)
        {
            HandleHits();
        }
    }

    void HandleHits()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;

        //Destroys the bricks depending the number of hits
        if (timesHit >= maxHits)
        {
            breakableCount--;
            levelManager.BrickDestroyed();
            SmokePuff();
            Destroy(gameObject);
            ScoreManager.score += ScoreValue;
            print(ScoreManager.score);
        }

        else
        {
            LoadSprites();
        }
    }

    void SmokePuff()
    {
        GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
        smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
    }

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;

        // This condition checks if the sprite is missing or not
        if (hitSprites[spriteIndex] != null)
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Brick Sprite Missing");
        }
    }
}
