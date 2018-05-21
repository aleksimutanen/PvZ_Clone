using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMPWave : MonoBehaviour {

    public float empDamage;
    float empDuration = 2f;

    void Update() {
        empDuration -= Time.deltaTime;
        if (empDuration < 0) {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision) {
        var b = collision.gameObject.GetComponent<Bot>();
        b.TakeDamage(empDamage);
        print("Emp active");
    }
}

