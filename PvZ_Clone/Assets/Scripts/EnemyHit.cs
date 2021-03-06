﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour {

    public GameObject ammo;
    public int healthLeft;
    GameManager gm;

    void Start() {
        gm = FindObjectOfType<GameManager>();
    }

    void Update() {
        if (healthLeft == 0) {
            Destroy(gameObject);
            gm.EnemyKilled(transform.position);
        }

    }

    //private void OnTriggerEnter(Collider other) {
    //    if (other.gameObject.name == "Ammo(Clone)") {
    //        healthLeft--;
    //        print("enemy hit");
    //    }
    //}

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name == "Ammo(Clone)") {
            Destroy(collision.gameObject);
            healthLeft--;
            print("enemy hit");
        }
    }
}


