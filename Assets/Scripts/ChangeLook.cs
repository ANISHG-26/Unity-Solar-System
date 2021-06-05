using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLook : MonoBehaviour
{
    public GameObject target;
    public AudioSource voiceOverAudio;

    // Update is called once per frame
    void OnMouseDown()
    {
        LookAt.target = target;
        Camera.main.fieldOfView = Mathf.Clamp(30 * target.transform.localScale.x, 1, 80);
        var foundAudioSourceObjects = FindObjectsOfType<AudioSource>();
        foreach (var audioSources in foundAudioSourceObjects)
        {
            if (audioSources != voiceOverAudio)
            {
                audioSources.Stop();
            }
        }

        if (!voiceOverAudio.isPlaying)
        {
            voiceOverAudio.PlayOneShot(voiceOverAudio.clip, 0.2f);
        }
    }
}
