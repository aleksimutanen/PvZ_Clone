using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoEShooter : MonoBehaviour {

    public float bugHealth;
    public GameObject ammo;
    public float firingspeed;
    float lastShot = 0f;
    public LayerMask enemyLayer;
    GameManager gm;
    public float hitPoint;
    public float middlePoint;
    public RaycastHit target;

    void Start() {
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    void Update() {

        if (Physics.Raycast(transform.position, transform.right, out target, Mathf.Infinity, enemyLayer)) {
            print("enemy spotted!!");
            //middlePoint = (transform.position.x + hit.point.x) / 2;
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

