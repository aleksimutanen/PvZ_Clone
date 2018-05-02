﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooter : MonoBehaviour {

    public GameObject ammo;
    public float firingspeed;
    float lastShot = 0f;
    public float maxRaycastDistance = 1f;
    public LayerMask enemyLayer;

    void Start() {

    }

    void Update() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, enemyLayer)) {
            if (Time.time > firingspeed + lastShot) {
                Instantiate(ammo, transform.position, transform.rotation);
                lastShot = Time.time;
            }
        }
    }
}
