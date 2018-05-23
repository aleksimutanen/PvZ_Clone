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
    GameManager gm;

    void Start() {
        gm = FindObjectOfType<GameManager>();
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
        }

    //private void OnTriggerEnter(Collider other) {
    //    //animaatiojotain
    //    //movespeed = 0f;
    //}

    private void OnTriggerStay(Collider other) {
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
        }
    }

    public bool TakeDamage(float damage) {
        botHealth -= damage;
        if (botHealth <= 0) {
            gm.EnemyKilled();
            Destroy(gameObject);
            return true;
        } else {
            state = EnemyState.Eating;
            EnemyStatusEnd(state);
        }
        return false;
    }
}




