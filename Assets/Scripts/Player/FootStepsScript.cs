using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepsScript : MonoBehaviour
{

    [SerializeField] private AudioClip[] clips;
    [SerializeField] private AudioClip slashClip;

    private AudioSource audioSource;

    // Start is called before the first frame update
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    private void Step()
    {
        AudioClip clip = GetRandomClip();
        audioSource.pitch = Random.Range(0.8f, 1.1f);
        audioSource.PlayOneShot(clip);
    }

    private void Slash()
    {
        AudioClip clip = slashClip;
        audioSource.pitch = Random.Range(0.8f, 1.1f);
        audioSource.PlayOneShot(clip);
    }

    private AudioClip GetRandomClip()
    {
        return clips[UnityEngine.Random.Range(0, clips.Length)];
    }
}
