using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    float movespeed = 1f;
    public GameObject enemy;

    private void Update() {
        transform.Translate(0, 0, -1 * (movespeed*Time.deltaTime));
    }

}
