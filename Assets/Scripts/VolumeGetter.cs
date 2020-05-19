using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Gets the volume of an audio source at a given point.
 * https://answers.unity.com/questions/1167177/how-do-i-get-the-current-volume-level-amplitude-of.html
 */
public class VolumeGetter : MonoBehaviour
{

    public AudioSource audioSource;
    public float updateStep = 0.1f;
    public int sampleDataLength = 1024;
    private float currentUpdateTime = 0f;

    private float clipLoudness;
    private float[] clipSampleData;

    void Awake()
    {
        clipSampleData = new float[sampleDataLength];
    }

    void Update()
    {
        currentUpdateTime += Time.deltaTime;
        if (currentUpdateTime >= updateStep)
        {
            currentUpdateTime = 0f;
            audioSource.clip.GetData(clipSampleData, audioSource.timeSamples);
            foreach (var sample in clipSampleData)
            {
                clipLoudness += Mathf.Abs(sample);
            }
            clipLoudness /= sampleDataLength;
        }
    }

    public float GetClipLoudness()
    {
        return clipLoudness;
    }
}
