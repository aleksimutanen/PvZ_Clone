using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landmine : MonoBehaviour, Bug {

    public float triggeringTime;
    bool willExplode;
    public float givenDamage;
    int enemyLayer;
    public float bugHealth;

    // Use this for initialization
    void Start() {
        willExplode = false;
        enemyLayer = LayerMask.NameToLayer("Enemy");
    }

    // Update is called once per frame
    void Update() {
        triggeringTime -= Time.deltaTime;

        if (triggeringTime < 0) {
            print("time out");
            willExplode = true;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (willExplode && other.gameObject.layer == enemyLayer){
            // other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            print ("explosion");
            var b = other.GetComponent<Bot>();
            b.TakeDamage(givenDamage);
            Destroy(gameObject);
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
