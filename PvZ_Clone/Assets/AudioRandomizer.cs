using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRandomizer : MonoBehaviour {

    public AudioSource sfx;
    public AudioClip[] deathSounds;
    public float maxPitch;
    float origPitch;

    void Start() {
        origPitch = sfx.pitch;
    }


    void Update() {

        if (Input.GetKeyDown(KeyCode.C)) {

            //float randomPitch = Random.Range(origPitch, maxPitch);
            //sfx.pitch = randomPitch; 

            sfx.PlayOneShot(deathSounds[Random.Range(0, deathSounds.Length)]);

            //sfx.Play();
        }

    }
}