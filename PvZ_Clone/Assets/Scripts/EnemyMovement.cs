using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState { Walking, Eating };

public class EnemyMovement : MonoBehaviour {

    public float movespeed = 1f;
    public GameObject enemy;
    public float damagePerSecond;
    EnemyState state;

    void EnemyStatusStart(EnemyState starting) {
        if (starting == EnemyState.Eating) {
            movespeed = 0f;
        }
    }

    void EnemyStatusEnd(EnemyState ending) {
        if (ending == EnemyState.Eating) {
            movespeed = 1f;
        }
    }

    void Update() {
        transform.Translate(0, 0, -1 * (movespeed * Time.deltaTime));
        if (gameObject.name == "EnemyFast") {
            movespeed = 2f;
        }
    }

    private void OnTriggerEnter(Collider other) {
        //animaatiojotain
        //movespeed = 0f;
    }

    private void OnTriggerStay(Collider other) {
        //movespeed = 0f;
        state = EnemyState.Eating;
        EnemyStatusStart(state);
        var b = other.GetComponent<Bug>();
        if (b != null) {
            b.TakeDamage(Time.deltaTime * damagePerSecond);
        } 
    }

    private void OnTriggerExit(Collider other) {
        print("exit");
        state = EnemyState.Walking;
        EnemyStatusEnd(state);
    }
}


