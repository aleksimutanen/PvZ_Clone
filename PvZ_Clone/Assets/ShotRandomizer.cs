using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotRandomizer : MonoBehaviour {

    public AudioSource sfx;
    public float maxPitch;
    float origPitch;

    void Start() {
        origPitch = sfx.pitch;
    }


    void Update() {

        if (Input.GetKeyDown(KeyCode.Space)) {

            float randomPitch = Random.Range(origPitch, maxPitch);
            sfx.pitch = randomPitch;
            
    
           
        }

    }
}