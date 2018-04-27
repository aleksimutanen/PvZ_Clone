using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooter : MonoBehaviour {

    public GameObject ammo;
    public float firingspeed;
    float lastShot = 0f;

	void Start () {
		
	}
	
	void Update () {
        //if (Input.GetKeyDown(KeyCode.Space)) {
        if (Time.time > firingspeed + lastShot) {
            Instantiate(ammo, transform.position, transform.rotation);
            lastShot = Time.time;
        }
	}
}
