using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour {

    public LayerMask enemy;
    GameManager gm;

    void Start() {
        gm = GameObject.FindObjectOfType<GameManager>();
        enemy = LayerMask.NameToLayer("Enemy");
    }

    void Update () {
		
	}

    //void OnCollisionEnter(Collision collision) {
    //    if (collision.gameObject == basicEnemy || durableEnemy || fastEnemy) {
    //        print("gameover");
    //        gm.GameOver();
    //    }
    //}

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == enemy) {
            print("gameover");
            gm.GameOver();
        }
    }
}
