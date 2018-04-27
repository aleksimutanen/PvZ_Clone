using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour {

    public GameObject ammo;
    public int healthLeft;

    void Start() {

    }

    void Update() {
        if (healthLeft == 0) {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision) {
        healthLeft--;
        print("enemy hit");
        }
    }


