using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoEAmmo : MonoBehaviour {
    public float speed;
    public float initialDamage;
    public float areaDamage;
	
	// Update is called once per frame
	void Update () {
        //transform.
		
	}
    void OnCollisionEnter(Collider other) {
        print("SPLASH!!!");
        var b = other.GetComponent<Bot>();
        b.TakeDamage(initialDamage);

        Destroy(gameObject);
    }
}
