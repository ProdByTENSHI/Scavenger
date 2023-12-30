using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private List<AudioClip> MusicClips;

    private AudioSource source;
    private int currentTrackID;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void Start()
    {
        PlayMusic(0);
    }

    private void PlayMusic(int clipID)
    {
        source.clip = MusicClips[clipID];
        currentTrackID = clipID;
        source.Play();
    }
}