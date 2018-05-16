using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState { Walking, Eating };

public class EnemyMovement : MonoBehaviour, Bot {

    float stateSpeed;
    public float movespeed;
    public GameObject enemy;
    public float damagePerSecond;
    EnemyState state;
    public float botHealth;

    void Start() {
    }

    void SetEnemyState(EnemyState newState) {
        EnemyStatusEnd(state);
        EnemyStatusStart(newState);
        state = newState;
    }

    void EnemyStatusStart(EnemyState starting) {
        if (starting == EnemyState.Eating) {
            movespeed = 0f;
        }
    }

    void EnemyStatusEnd(EnemyState ending) {
        if (ending == EnemyState.Eating) {
            movespeed = 0.15f;
        }
    }

    void Update() {
        transform.Translate(0, 0, -1 * (movespeed * Time.deltaTime));
        //if (gameObject.name == "EnemyFast") {
        //    movespeed = 2f;
        //}
    }
    //private void OnTriggerEnter(Collider other) {
    //    //animaatiojotain
    //    //movespeed = 0f;
    //}

    private void OnTriggerStay(Collider other) {
        //movespeed = 0f;
        print("stop");
        state = EnemyState.Eating;
        EnemyStatusStart(state);
        var b = other.GetComponent<Bug>();
        if (b != null) {
            bool dead = b.TakeDamage(Time.deltaTime * damagePerSecond);
            if (dead) {
                print("bug died");
                state = EnemyState.Eating;
                EnemyStatusEnd(state);
            }

            //if (b == null) {
            //    print("keep walking");  
            //    state = EnemyState.Walking;
            //    EnemyStatusEnd(state);
        }
        //o.Moving();
        }

    public bool TakeDamage(float damage) {
        botHealth -= damage;
        if (botHealth <= 0) {
            Destroy(gameObject);
            return true;
        } else {
            state = EnemyState.Eating;
            EnemyStatusEnd(state);
        }
        return false;
        //if (botHealth > 0) {
        //    state = EnemyState.Walking;
        //    EnemyStatusStart(state);
        //}

        //public bool TakeDamage(float damage) {
        //    bugHealth -= damage;
        //    if (bugHealth <= 0) {
        //        Destroy(gameObject);
        //        return true;
        //    }
        //    return false;
        //}
    }

    //private void OnTriggerExit(Collider other) {
    //    print("exit");
    //    state = EnemyState.Walking;
    //    EnemyStatusEnd(state);
    //}
}




