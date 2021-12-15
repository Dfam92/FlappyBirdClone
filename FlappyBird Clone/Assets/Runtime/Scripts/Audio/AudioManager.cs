using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;


    public void PlayAudio (AudioClip clips)
    {
        audioSource.PlayOneShot(clips);
    }
}
