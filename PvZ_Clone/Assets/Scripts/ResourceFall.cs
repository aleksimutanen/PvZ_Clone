using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceFall : MonoBehaviour {
    //public float fallSpeed;
    //GameManager gm;
    //float distanceThreshold = 0.93f;
    float destroyTimer = 8f;
    float growingSpeed = 0.1f;
    bool vanishing = false;

    private void Start() {
        //gm = FindObjectOfType<GameManager>();
        transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
    }

    void FixedUpdate() {

        transform.localScale += new Vector3(growingSpeed, growingSpeed, growingSpeed) * Time.deltaTime;

        if (transform.localScale.x > 0.34f) {
            growingSpeed = 0f;
        }
        if (growingSpeed == 0f) {
            destroyTimer -= Time.deltaTime;
        }
        if (destroyTimer <= 0) {
            transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f) * Time.deltaTime;
            vanishing = true;
        }
        if (transform.localScale.x < 0.34f && vanishing) {
            transform.position += Vector3.up * 0.5f * Time.deltaTime;
        }
        if (transform.localScale.x < 0.05f) {
            Destroy(gameObject);
        }




        //transform.position += Vector3.down * fallSpeed * Time.deltaTime;
        //    if (Vector3.Distance(transform.position, gm.targetPos) <= distanceThreshold) {
        //        fallSpeed = 0f;
        //    }
        //    if (fallSpeed <= 0f) {
        //        destroyTimer -= Time.deltaTime;
        //        if (destroyTimer <= 0) {
        //            transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f) * Time.deltaTime;
        //            if (transform.localScale.x < 0.1f) {
        //                Destroy(gameObject);
        //            }
        //        }
        //    }
        //}
    }
}

