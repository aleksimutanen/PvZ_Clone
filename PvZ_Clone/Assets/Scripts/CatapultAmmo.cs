using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultAmmo : MonoBehaviour {

    public int numberOfSides;
    public float polygonRadius;
    public Vector2 polygonCenter;

    public float ammoDamage = 1f;
    public float ammospeed;
    public float ammoDuration;
    public GameObject recource;

    // Update is called once per frame
    void Update() {
        //Debug.DrawLine(polygonCenter, polygonRadius, numberOfSides);

        transform.Translate(0, 0, ammospeed * Time.deltaTime);
        ammoDuration -= Time.deltaTime;
        if (ammoDuration < 0) {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision) {
        var b = collision.gameObject.GetComponent<Bot>();
        b.TakeDamage(ammoDamage);
        print("ammo hit");
        Destroy(gameObject);
    }
}
