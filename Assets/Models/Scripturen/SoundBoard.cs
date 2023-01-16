using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBoard : MonoBehaviour
{

    private AudioSource aud;
    public List<AudioClip> geluiden = new List<AudioClip>();

    void Start()
    {
        aud = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaySound(int giveIndex)
    {
        aud.PlayOneShot(geluiden[giveIndex]);
    }

}
