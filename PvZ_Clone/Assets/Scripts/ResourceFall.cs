using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceFall : MonoBehaviour {
    public float fallSpeed;
    GameManager gm;
    float distanceThreshold = 0.93f;
    float destroyTimer = 8f;

    private void Start() {
        gm = FindObjectOfType<GameManager>();

    }

    void FixedUpdate() {

        transform.position += Vector3.down * fallSpeed * Time.deltaTime;
        if (Vector3.Distance(transform.position, gm.targetPos) <= distanceThreshold) {
            fallSpeed = 0f;
        }
        if (fallSpeed <= 0f) {
            destroyTimer -= Time.deltaTime;
            if (destroyTimer <= 0) {
                transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f) * Time.deltaTime;
                if (transform.localScale.x < 0.1f) {
                    Destroy(gameObject);
                }
            }
        }
    }
}
