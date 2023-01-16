using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour {

    [SerializeField] private float       maxPitch;
    [SerializeField] private float       minPitch;
    [SerializeField] private AudioSource effects;
    [SerializeField] private AudioSource music;
    
    public void Play(AudioClip clip) {
        effects.pitch = Random.Range( minPitch , maxPitch );
        effects.clip = clip;
        effects.Play();
    }

    public void MusicPlay( AudioClip clip ) {
        music.clip = clip;
        music.Play();
    }
    
    public void RandomPlay( AudioClip[] clips ) {
        AudioClip clip = clips[Random.Range(0,clips.Length - 1)];
        music.PlayOneShot(clip);    
    }
}
