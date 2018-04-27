using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public float movespeed = 1f;
    public GameObject enemy;

    private void Update() {
        transform.Translate(0, 0, -1 * (movespeed*Time.deltaTime));
        if (gameObject.name == "EnemyFast") {
            movespeed = 2f;
        }
    }

}
