using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoNiko : MonoBehaviour {
    public float ammospeed;

    void Update() {
        transform.Translate(0, 0, ammospeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision) {
        Destroy(gameObject);
    }
}
