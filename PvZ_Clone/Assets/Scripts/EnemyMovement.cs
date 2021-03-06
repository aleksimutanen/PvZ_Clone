﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState { Walking, Eating, Freezed };

public class EnemyMovement : MonoBehaviour, Bot {

    EaterList el;
    float stateSpeed;
    public float movespeed;
    public GameObject enemy;
    public float damagePerSecond;
    public EnemyState state;
    public float botHealth;
    GameManager gm;
    public float freezeTime = 0f;
    public float freezeTimeout = 3f;
    SpriteRenderer sr;
    public float hitfadespeed;
    Animator animator;
    public string hitanimation;
    public string walkinganimation;
    ShieldFlash sf;
    public AudioSource rob;
    public AudioClip robdeath;
    public AudioSource movement;
    public AudioClip move;
    public AudioClip punch;
    public AudioSource hit;

    private void Awake() {
        sr = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        sf = GetComponentInChildren<ShieldFlash>();
    }

    void Start() {
        gm = FindObjectOfType<GameManager>();
        animator = GetComponentInChildren<Animator>();
    }

    void SetEnemyState(EnemyState newState) {
        EnemyStatusEnd(state);
        EnemyStatusStart(newState);
        state = newState;
    }

    public void EnemyStatusStart(EnemyState starting) {
        if (starting == EnemyState.Eating) {
            movespeed = 0f;
            movement.Stop();
            if (!hit.isPlaying) {
                hit.PlayOneShot(punch);
            }

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
        if (state == EnemyState.Walking || state == EnemyState.Freezed) {
            if (!movement.isPlaying) {
                movement.PlayOneShot(move);
            }
        }
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

        sr.color += Color.white * hitfadespeed * Time.deltaTime;
    }


    private void OnTriggerStay(Collider other) {
        var b = other.GetComponent<Bug>();
        if (b != null) {
            state = EnemyState.Eating;
            EnemyStatusStart(state);
            
            if (el == null) {
                el = other.GetComponent<EaterList>();
                el.RegisterEater(this);
            } else {
                if (el != other.GetComponent<EaterList>())
                    Debug.LogError("was eating something else!");
            }
            //var d = other.GetComponent<EaterList>();
            //el.RegisterEater(this);
            
            animator.Play(hitanimation);
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
            el = null;
            
            EnemyStatusEnd(state);
            state = EnemyState.Walking;
            animator.Play(walkinganimation);
        }
    }

    public void ResetColor() {
        sr.color = Color.white;
    }

    public void TakeDamage(float damage) {
        if (botHealth <= 0) {
            return;
        }
        if (sf) {
            var shieldDestroyed = sf.TakeDamage(damage);
            if (shieldDestroyed) {
                sf = null;
            }
        } else {
            botHealth -= damage;
            Color c;
            ColorUtility.TryParseHtmlString("#B01515", out c);
            sr.color = c;

            if (botHealth <= 0) {
                gm.EnemyKilled(transform.position);
                if (el) {
                    el.eaters.Remove(this);
                    
                }
                AudioSource.PlayClipAtPoint(robdeath, Camera.main.transform.position);
                Destroy(gameObject);
            }
        }
    }
}





