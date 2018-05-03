using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoNiko : MonoBehaviour {
    public float ammospeed;
    public float ammoDuration;
    public GameObject recource;

    void Update() {
        transform.Translate(0, 0, ammospeed * Time.deltaTime);
        ammoDuration -= Time.deltaTime;
        if(ammoDuration < 0) {
            Destroy(gameObject);
        }
    }

    //private void OnTriggerEnter(Collider other) {
    //    if (other.gameObject == !recource) {
    //        print("ammo hit");
    //        Destroy(gameObject);
    //    }
    //}
    // this is for without rigidbody

    void OnCollisionEnter(Collision collision) {
            print("ammo hit");
            Destroy(gameObject);
        }
    }

