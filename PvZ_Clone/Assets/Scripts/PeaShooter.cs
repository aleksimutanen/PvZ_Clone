using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooter : MonoBehaviour, Bug {

    public float bugHealth;
    public GameObject ammo;
    public float firingspeed;
    float lastShot = 0f;
    public float maxRaycastDistance = 1f;
    public LayerMask enemyLayer;
    GameManager gm;

    void Start() {
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    void Update() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, enemyLayer)) {
            if (Time.time > firingspeed + lastShot) {
                GameObject go = Instantiate(ammo, transform.position, transform.rotation);
                go.transform.parent = gm.spawnFolder;
                lastShot = Time.time;
            }
        }
    }

    public bool TakeDamage(float damage) {
        bugHealth -= damage;
        if (bugHealth <= 0) {
            Destroy(gameObject);
            return true;
        }
        return false;
    }
}
