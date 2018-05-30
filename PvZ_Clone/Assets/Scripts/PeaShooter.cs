﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EaterList))]
public class PeaShooter : MonoBehaviour, Bug {

    
    public float bugHealth;
    public GameObject ammo;
    public float firingspeed;
    float lastShot = 0f;
    public float maxRaycastDistance = 1f;
    public LayerMask enemyLayer;
    GameManager gm;
    Animator animator;

   

    public void Shoot() {
        GameObject go = Instantiate(ammo, transform.position - new Vector3(-0.3f, 0.2f, 0f), transform.rotation);
        go.transform.parent = gm.spawnFolder;
    }

    void Start() {
        gm = GameObject.FindObjectOfType<GameManager>();
        animator = GetComponent<Animator>();
    }

    void Update() {

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.right, out hit, Mathf.Infinity, enemyLayer)) {
            if (Time.time > firingspeed + lastShot) {
                animator.Play("antshoot");
                lastShot = Time.time;
            }
        }
    }

    public void TakeDamage(float damage) {
        bugHealth -= damage;
        if (bugHealth <= 0) {
            GetComponent<EaterList>().NotifyEaters();
            Destroy(gameObject);
            //return true;
        }
        //return false;
    }

    
}
