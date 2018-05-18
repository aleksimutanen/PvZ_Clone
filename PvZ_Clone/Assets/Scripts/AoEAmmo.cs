using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoEAmmo : MonoBehaviour {
    public float ammoSpeed;
    public float shotHighpoint;
    public float initialDamage;
    public float areaDamage;
    float midPoint;
    float target;

    void Start() {
        midPoint = GameObject.FindObjectOfType<AoEShooter>().middlePoint;
        print(midPoint);
        target = GameObject.FindObjectOfType<AoEShooter>().hitPoint;
        print(target);

    }

    // Update is called once per frame
    void Update () {
        //transform.Translate(middlePoint, shotHighpoint, ammoSpeed * Time.deltaTime);
        //Debug.DrawLine(transform.position, (shotHighpoint, 0, midPoint), Color );
        transform.Translate(shotHighpoint, 0, midPoint);

        }

    void OnCollisionEnter(Collision collision) {
        print("SPLASH!!!");
        var b = collision.gameObject.GetComponent<Bot>();
        b.TakeDamage(initialDamage);
        Destroy(gameObject);
    }
}
