using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatteredEnemy : MonoBehaviour
{

    public float minSpeed;
    public float maxSpeed;
    // Degrees that the piece can deviate from the given direction
    public float spread;
    public float maxRotation;
    Rigidbody2D[] pieces;
    // Use this for initialization
    void Start()
    {
        pieces = GetComponentsInChildren<Rigidbody2D>();
        // face a random direction.
        transform.rotation = Quaternion.AngleAxis(Random.Range(0, 360), Vector3.forward);
        // randomly flip
        Vector3 scale = new Vector3(1, 1, 1);
        if (Random.value > .5)
        {
            scale.x = -1;
        }
        if (Random.value > .5)
        {
            scale.y = -1;
        }

        transform.localScale = scale;
    }

    public void SetColor(Color col)
    {
        SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer sr in sprites)
        {
            sr.color = col;
        }
    }


    public void Shatter(Vector3 direction)
    {
        // basically a fake, basic particle system.
        foreach (Rigidbody2D rb in pieces)
        {
            rb.simulated = true;
            Vector2 dir = (Vector2)(Quaternion.AngleAxis(Random.Range(-spread, spread), Vector3.forward) * direction);
            rb.AddForce(dir * Random.Range(minSpeed, maxSpeed), ForceMode2D.Impulse);
            rb.AddTorque(Random.Range(-maxRotation, maxRotation));
        }
    }
}
