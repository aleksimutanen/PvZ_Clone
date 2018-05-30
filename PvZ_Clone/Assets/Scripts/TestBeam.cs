using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBeam : MonoBehaviour {

    public GameObject EMP;

	void Start () {
        EMP.SetActive(false);
	}

    private void Update() {
        //Physics.RaycastAll;
    }
    void OnTriggerEnter(Collider other) {
       var b = other.gameObject.GetComponent<Bot>();
        EMP.SetActive(true);
    }
    
}
