using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headBob : MonoBehaviour {
    
    [SerializeField] private float          speed;
    [SerializeField] private float          amount;
    [SerializeField] private PlayerMovement controller;
    [SerializeField] private GameObject     camAnchor;
    [SerializeField] private SoundScript    src;
    [SerializeField] private AudioClip[]    clips;

    private float defaultY;
    private float timer;

    void Start() {
        defaultY = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update() {
        if(controller.X > .1f || controller.Z > .1f || controller.X < -.1f || controller.Z < -.1f)
        {
            timer += Time.deltaTime * speed;
            transform.localPosition = new Vector3(transform.localPosition.x, defaultY + Mathf.Sin(timer) * amount, transform.localPosition.z);
        }
        else
        {
            timer = 0;
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Lerp(transform.localPosition.y, defaultY, Time.deltaTime * speed), transform.localPosition.z);
        }
    }
}
