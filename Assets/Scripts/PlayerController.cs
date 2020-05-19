using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public int health;

    public Bullet bulletType;
    public Chromasplosion chromasplosionType;

    public float repeatRate; // Bullets fired per second I guess;
    float timeSinceLastFire;

    public int splosions = 3;
    // public VolumeGetter volumeGetter;
    // Vector3 targetScale;

    void Start()
    {
        // volumeGetter = GetComponent<VolumeGetter>();
    }


    void Update()
    {
        // Control gun
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletType, transform.position, transform.rotation);
            timeSinceLastFire = 0.0f;

        }
        // TODO: Zen Mode
        // Auto repeat so people don't break their fingers off
        // if (Input.GetMouseButton(0))
        // {
        //     timeSinceLastFire += Time.deltaTime;
        //     if (timeSinceLastFire > 1 / repeatRate)
        //     {
        //         Instantiate(bulletType, transform.position, transform.rotation);
        //         timeSinceLastFire = 0.0f;
        //     }
        // }
        // Chromasplosion or whatever i'm calling it
        if (Input.GetKeyDown(KeyCode.Space) && splosions > 0 && GetComponentInChildren<Chromasplosion>() == null)
        {
            splosions--;
            Instantiate(chromasplosionType, transform.position, transform.rotation, transform);
        }
        // // Change size to match music (hopefully)
        // Vector3 v = transform.localScale;
        // v.x = 1 + (volumeGetter.GetClipLoudness() * 2f - .5f);
        // v.y = 1 + (volumeGetter.GetClipLoudness() * 2f - .5f);
        // targetScale = v;
        // transform.localScale = Vector3.Lerp(transform.localScale, targetScale, .2f);
    }

    void FixedUpdate()
    {
        // Rotate to face camera.
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

}
