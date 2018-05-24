using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Display_EnemyAtStart : MonoBehaviour {

    GameManager gm;
    public GameObject EnemyOverview;

    private void Start() {
        gm = GetComponent<GameManager>();
    }
    void Update () {
	    if (transform.position.x > 0.8f) {
            EnemyOverview.SetActive(true); 
        }	
        if (transform.position.x < 0.3f) {
            EnemyOverview.SetActive(false);
        }
	}
}

