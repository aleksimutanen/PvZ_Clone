using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoEAmmo : MonoBehaviour {
    public float ammoSpeed;
    public float shotHighpoint;
    public float initialDamage;
    public float areaDamage;
    public GameObject AoEShooter;
    //public float middlePoint;
    //public float hitPoint;
    AoEShooter Shooter;

    void Start() {
        //Shooter = GetComponent<AoEShooter>();
    }

    // Update is called once per frame
    void Update () {
        //transform.Translate(middlePoint, shotHighpoint, ammoSpeed * Time.deltaTime);
        transform.Translate(Shooter.middlePoint, 0, ammoSpeed * Time.deltaTime);

        }

    void OnCollisionEnter(Collision collision) {
        print("SPLASH!!!");
        var b = collision.gameObject.GetComponent<Bot>();
        b.TakeDamage(initialDamage);
        Destroy(gameObject);
    }
}
