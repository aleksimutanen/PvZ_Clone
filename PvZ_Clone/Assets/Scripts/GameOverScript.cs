using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour {

    public GameObject basicEnemy;
    public GameObject durableEnemy;
    public GameObject fastEnemy;
    GameManager gm;

    void Start() {
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    void Update () {
		
	}

    void OnTriggerEnter(Collider other) {
        if(other == basicEnemy || durableEnemy || fastEnemy) {
            print("gamover");
            gm.GameOver();
        }
    }
}
