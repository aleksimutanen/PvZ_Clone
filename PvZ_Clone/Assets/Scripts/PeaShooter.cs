using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooter : MonoBehaviour {

    public GameObject ammo;

	void Start () {
		
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(ammo);
            transform.position = ammo.transform.position;
            ammo.transform.Translate(1, 2, 0);
        }
		
	}
}
