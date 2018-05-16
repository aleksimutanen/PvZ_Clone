using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, Bug {
    //lisää muihin bugeihin
    public float bugHealth;

	void Start () {

	}

    //public void Moving() {
    //    movespeed = 1f;
    //}
	
	//void Update () {
 //       if(wallHealth < 0) {
 //           Destroy(gameObject);
 //       }
	//}

 //   private void OnTriggerEnter(Collider other) {
 //       wallHealth -= Time.deltaTime;
 //       em.Eating();
 //   }

    //returns true if bug dies
    public bool TakeDamage(float damage) {
        bugHealth -= damage;
        if (bugHealth <= 0) {
            Destroy(gameObject);
            return true;
        }
        return false;
    }
}
