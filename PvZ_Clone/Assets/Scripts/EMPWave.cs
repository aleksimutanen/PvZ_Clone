using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMPWave : MonoBehaviour {

    public float empDamage;
    float empDuration = 1.4f;
    Animator animator;
    SpriteRenderer sr;
    public string beamanimation;

    private void Awake() {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update() {
        empDuration -= Time.deltaTime;
        if (empDuration < 0) {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision) {
        animator.Play(beamanimation);
        var b = collision.gameObject.GetComponent<Bot>();
        b.TakeDamage(empDamage);
        b.TakeDamage(empDamage);
        print("Emp active");
    }
}

