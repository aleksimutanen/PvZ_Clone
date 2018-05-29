using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoEAmmo : MonoBehaviour {

    public Transform target;
    public float ammoSpeed;
    public float shotHighpoint;
    public float initialDamage;
    public float areaDamage;
    //float midPoint;
    //float target;

    void Start() {
        //midPoint = GameObject.FindObjectOfType<AoEShooter>().middlePoint;
        //print(midPoint);
        //target = GameObject.FindObjectOfType<AoEShooter>().hitPoint;
        //print(target);

    }

    // Update is called once per frame
    void Update () {
        //transform.Translate((target.position) * ammoSpeed * Time.deltaTime);
        //transform.position.x += target.position.x * ammoSpeed * Time.deltaTime;
        transform.Translate(target.position.x * ammoSpeed * Time.deltaTime, 0, 0);
        //transform.Translate(midPoint, shotHighpoint, 0, Space.World);
        //Debug.DrawLine(transform.position, ), Color );
        //transform.Translate(shotHighpoint, 0, midPoint);

        }

    void OnCollisionEnter(Collision collision) {
        print("SPLASH!!!");
        var b = collision.gameObject.GetComponent<Bot>();
        b.TakeDamage(initialDamage);
        Destroy(gameObject);
    }
}
