using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Filter : MonoBehaviour
{

    SpriteRenderer sr;
    PlayerController player;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        player = FindObjectOfType<PlayerController>();
    }

    // Really stupidly, unity doesn't let you change stuff on gameobjects with an animator
    // unless you do it from LateUpdate().
    void LateUpdate()
    {
        // Get bigger if the player is facing you
        // Thanks stackoverflow
        float a = transform.eulerAngles.z - 90;
        float b = player.transform.eulerAngles.z;
        float d = Mathf.Abs(b - a) % 360;
        float r = d > 180 ? 360 - d : d;
        r /= 180;
        Vector3 v = transform.localScale;
        v.y = 1 + ((1 - r) * 1.0f);
        transform.localScale = v;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Camera.main.backgroundColor = Color.Lerp(sr.color, Color.black, .5f);
            Destroy(gameObject);
        }
    }
}
