using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    // how far in units the camera is allowed to move
    public float panRange;

    public float defaultAmplitude = 1f;
    public float amplitude = 1f;
    public float duration = .2f;

    public float startShakeTime;
    public float endShakeTime;

    private Camera cam;
    // Use this for initialization
    void Start()
    {
        cam = GetComponent<Camera>();
        endShakeTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // Move in the direction of the mouse.
        Vector2 pos = Input.mousePosition;
        pos.x /= Screen.width;
        pos.y /= Screen.height;
        pos.x -= .5f;
        pos.y -= .5f;
        pos.x *= panRange;
        pos.y *= panRange;
        // Handle screen shake.
        if (Time.time < endShakeTime)
        {
            float t = Time.time - startShakeTime;
            float t2 = endShakeTime - startShakeTime;
            float amp = amplitude * (1 - (t / t2));
            pos.x += Random.Range(-amp, amp);
            pos.y += Random.Range(-amp, amp);
        }
        transform.position = new Vector3(pos.x, pos.y, -1);

        // Update color
        cam.backgroundColor = Color.Lerp(cam.backgroundColor, Color.black, .05f);
    }

    /**
     * Shake the screen!
     */
    public void Shake(float percent)
    {
        amplitude = defaultAmplitude * Mathf.Clamp(percent, 0, 1);
        startShakeTime = Time.time;
        endShakeTime = Time.time + duration;
    }
}
