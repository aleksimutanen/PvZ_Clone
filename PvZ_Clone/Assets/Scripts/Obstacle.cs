using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EaterList))]
public class Obstacle : MonoBehaviour, Bug {
    //lisää muihin bugeihin
    public float bugHealth;
    public Sprite maxhp;
    public Sprite firstcrack;
    public Sprite secondcrack;
    public Sprite thirdcrack;

    SpriteRenderer sr;

	void Awake () {
        sr = GetComponent<SpriteRenderer>();
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
    public void TakeDamage(float damage) {
        bugHealth -= damage;
        if (bugHealth >= 10) {
            sr.sprite = maxhp;
        }
        else if (bugHealth >= 8) {
            print("shieet");
            sr.sprite = firstcrack;
        }
        else if (bugHealth >= 6) {
            sr.sprite = secondcrack;
        }
        else if (bugHealth >= 4) {
            sr.sprite = thirdcrack;
        }
        if (bugHealth <= 0) {
            Destroy(gameObject);
            //return true;
        }
        //return false;
    }
}
