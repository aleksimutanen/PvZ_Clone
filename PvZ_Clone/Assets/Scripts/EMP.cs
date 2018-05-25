using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMP : MonoBehaviour {

    public GameObject empWave;
    float destroyTimer = 2f;
    bool active;

	void Start () {
        empWave.SetActive(false);
        active = false;
	}
    void Update() {

        if (active) {
            destroyTimer -= Time.deltaTime;
            if (destroyTimer <= 0) {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        empWave.SetActive(true);
        active = true;
    }
}
