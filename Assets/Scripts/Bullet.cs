using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed;
    ParticleSystem ps;
    SpriteRenderer sr;
    Rigidbody2D rb;
    // Use this for initialization
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;

        var m = ps.main;
        m.startRotation = -transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        // ps.Stop();
    }

    // Update is called once per frame
    void UpdateColor(Color color)
    {
        sr.color = color;
        Gradient grad = new Gradient();
        grad.SetKeys(
            new GradientColorKey[] {
                new GradientColorKey(sr.color, 0.0f)
            },
            new GradientAlphaKey[] {
                new GradientAlphaKey(1.0f, 0.0f),
                new GradientAlphaKey(0.0f, 1.0f)
            }
        );

        var col = ps.colorOverLifetime; // I have no idea why unity is like this...

        col.color = grad;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Filter":
                UpdateColor(other.gameObject.GetComponent<SpriteRenderer>().color);
                break;
            case "Enemy":
                Destroy(gameObject);
                break;
            default:
                break;
        }

    }
}
