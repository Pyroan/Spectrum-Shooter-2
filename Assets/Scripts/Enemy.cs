using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public int maxHealth;
    public int health;
    public int maxKnockback;
    public float acceleration;
    public float speed;
    SpriteRenderer sr;
    Rigidbody2D rb;
    ShatteredEnemy corpse;
    Vector2 velocity;

    public Text scoretext;
    AudioSource audioSource;

    Color color;
    public float fadeDuration = 1f;
    Color flashColor;
    float fadeAmount = 0f;
    bool isAlive;
    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        color = Color.HSVToRGB(Random.value, 1f, 1f);
        sr.color = color;
        flashColor = color;
        corpse = GetComponentInChildren<ShatteredEnemy>();
        corpse.SetColor(sr.color);
        isAlive = true;

        audioSource = GetComponent<AudioSource>();

        rb = GetComponent<Rigidbody2D>();
        velocity = -transform.position.normalized * speed;
        rb.velocity = velocity;
    }

    void Update()
    {
        if (fadeAmount < fadeDuration)
        {
            sr.color = Color.Lerp(flashColor, color, fadeAmount / fadeDuration);
            fadeAmount += Time.deltaTime;
        }
    }
    void FixedUpdate()
    {
        rb.velocity = Vector2.Lerp(rb.velocity, velocity, acceleration);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet" && isAlive)
        {
            // Handle damage.

            float a, b, d, r;
            Color.RGBToHSV(other.GetComponent<SpriteRenderer>().color, out a, out d, out r);
            // check if the bullet is white
            if (d < .5f)
            {
                r = .1f;

            }
            else
            {
                Color.RGBToHSV(sr.color, out b, out d, out r);
                d = Mathf.Abs(b - a);
                r = d > .5f ? 1 - d : d;
                r /= .5f;
                r = 1 - r;
                // Make crits easier
                if (r > .9f)
                {
                    r = 1.5f;
                }
                // Make flubs okay
                if (r < .1f)
                {
                    r = .1f;
                }
            }
            audioSource.pitch = r * .5f + .5f;
            // audioSource.Play();
            health -= (int)(maxHealth * r);
            if (health <= 0)
            {
                Die();
            }
            // Move back and shake screen based on how intense the damage was
            rb.AddForce(-velocity * (r * maxKnockback), ForceMode2D.Impulse);
            Camera.main.GetComponent<CameraController>().Shake(r);
            flashColor = Color.Lerp(color, Color.white, .1f + r);
            fadeAmount = 0;
        }
        else if (other.gameObject.tag == "Filter" && isAlive)
        {
            Destroy(gameObject);
        }
    }

    void Die()
    {
        isAlive = false;
        rb.simulated = false;
        sr.enabled = false;
        Vector3 dir = FindObjectOfType<PlayerController>().transform.position - transform.position;
        dir.Normalize();
        corpse.Shatter(-dir);
        FindObjectOfType<GameManager>().IncrementScore();
        Text t = Instantiate(scoretext, FindObjectOfType<Canvas>().transform);
        t.transform.position = transform.position;
        t.text = "" + FindObjectOfType<GameManager>().GetScore();
    }
}
