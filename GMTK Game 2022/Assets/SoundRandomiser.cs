using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRandomiser : MonoBehaviour
{

    AudioSource audioSource;

    public AudioClip[] clips;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clips[Random.Range(0, clips.Length)];
        audioSource.Play();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
