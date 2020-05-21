using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

/**
 *  Handles bloom in stuff like menus.
 */
public class BloomController : MonoBehaviour
{
    Bloom bloom;
    public float offset;
    // Start is called before the first frame update
    void Start()
    {
        PostProcessVolume volume = GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out bloom);
    }

    // Update is called once per frame
    void Update()
    {
        bloom.color.value = Color.HSVToRGB(((Time.time * 30 + offset) % 360) / 360, 1, 1);
    }
}
