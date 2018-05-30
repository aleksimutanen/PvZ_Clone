﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState { Walking, Eating, Freezed };

public class EnemyMovement : MonoBehaviour, Bot {

    float stateSpeed;
    public float movespeed;
    public GameObject enemy;
    public float damagePerSecond;
    public EnemyState state;
    public float botHealth;
    GameManager gm;
    public float freezeTime = 0f;
    public float freezeTimeout = 3f;

    void Start() {
        gm = FindObjectOfType<GameManager>();
    }

    void SetEnemyState(EnemyState newState) {
        EnemyStatusEnd(state);
        EnemyStatusStart(newState);
        state = newState;
    }

    public void EnemyStatusStart(EnemyState starting) {
        if (starting == EnemyState.Eating) {
            movespeed = 0f;
        } else if (starting == EnemyState.Freezed) {
            movespeed = movespeed / 2;
        }
    }


    void EnemyStatusEnd(EnemyState ending) {
        if (ending == EnemyState.Eating || ending == EnemyState.Freezed) {
            if (gameObject.name == ("EnemyFast(Clone)")) {
                movespeed = 0.3f;
            } else {
                movespeed = 0.15f;
            }
        }
    }

    void Update() {
        transform.Translate(-1 * movespeed * Time.deltaTime, 0, 0);
        if (state == EnemyState.Freezed) {
            freezeTime += Time.deltaTime;
            if (freezeTime > freezeTimeout) {
                state = EnemyState.Freezed;
                EnemyStatusEnd(state);
                state = EnemyState.Walking;
                freezeTime = 0f;
            }
        }
        //if (state == EnemyState.Walking && movespeed == 0f) {
        //    if (gameObject.name == ("EnemyFast(Clone)")) {
        //        movespeed = 0.3f;
        //    } else {
        //        movespeed = 0.15f;
        //    }
        //}
    }

    //private void OnTriggerEnter(Collider other) {
    //    //animaatiojotain
    //    //movespeed = 0f;
    //}

    private void OnTriggerStay(Collider other) {
        var b = other.GetComponent<Bug>();
        if (b != null) {
            state = EnemyState.Eating;
            EnemyStatusStart(state);
            other.GetComponent<EaterList>().RegisterEater(this);
            b.TakeDamage(Time.deltaTime * damagePerSecond);
            //state = EnemyState.Walking;
            //if (dead) {
            //    print("bug died");
            //    state = EnemyState.Eating;
            //    EnemyStatusEnd(state);
                //state = EnemyState.Walking;
            }
        }
    

    public void NotifyBugEaten() {
        if (state == EnemyState.Eating) {
            EnemyStatusEnd(state);
            state = EnemyState.Walking;
        }
    }

    public void TakeDamage(float damage) {
        botHealth -= damage;

        if (botHealth <= 0) {
            gm.EnemyKilled();
            Destroy(gameObject);
            //return true;
        } /*else {*/
          //state = EnemyState.Eating;
          //EnemyStatusEnd(state);
        //return false;
    }
}





