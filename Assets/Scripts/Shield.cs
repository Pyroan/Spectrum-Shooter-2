using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public int shieldsegments;
    public float shieldDistance;
    public Filter shieldtype;
    public float shieldSpeed;

    public float spawnspeed; // literally just for animating.
    bool spawned = false;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(InitShield());
    }

    IEnumerator InitShield()
    {
        float angleStep = 360f / shieldsegments;
        Vector3 pos = transform.position;
        // Position of the first shield segment relative to player position
        Vector3 component = new Vector3(shieldDistance, 0, pos.z);
        for (int i = 0; i < shieldsegments; i++)
        {
            float theta = transform.eulerAngles.z + (angleStep * i);
            float cos = Mathf.Cos(theta * Mathf.Deg2Rad);
            float sin = Mathf.Sin(theta * Mathf.Deg2Rad);
            Vector3 rotated = new Vector3(
                (cos * component.x) - (sin * component.y),
                (sin * component.x) + (cos * component.y),
                component.z
                );
            Filter newSegment = Instantiate(shieldtype, pos + rotated, Quaternion.AngleAxis(theta + 90, Vector3.forward), transform);
            newSegment.GetComponent<SpriteRenderer>().color = Color.HSVToRGB((float)i / shieldsegments, 1f, 1f);

            yield return new WaitForSeconds(spawnspeed);
        }
        spawned = true;
    }


    void FixedUpdate()
    {
        // if (!spawned) return;
        // Control Shield
        float rot = -Input.GetAxisRaw("Horizontal");
        transform.Rotate(0f, 0f, rot * shieldSpeed);
    }

    public bool GetSpawned()
    {
        return spawned;
    }
}
