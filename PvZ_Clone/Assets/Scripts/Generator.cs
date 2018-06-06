using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EaterList))]
public class Generator : MonoBehaviour, Bug {

    public GameObject recourcePrefab;
    public float recourceAmount = 0f;
    public float recourceSpawn;
    float timeSinceLastRecource = 0f;
    public Transform dropPosition;
    public float bugHealth;
    GameManager gm;
    SpriteRenderer sr;
    public float flashspeed;
    bool lastdamageTaken;

    void Start() {
        gm = FindObjectOfType<GameManager>();
        timeSinceLastRecource = Time.time;
    }

    void Awake() {
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    void FixedUpdate() {
        if (lastdamageTaken == false) {
            sr.material.SetFloat("_FlashAmount", 0);
        }
        lastdamageTaken = false;
    }

    void Update() {

        if (Time.time > recourceSpawn + timeSinceLastRecource) {
            GameObject go = Instantiate(recourcePrefab, dropPosition.transform.position, transform.rotation);
            go.transform.parent = gm.spawnFolder;
            timeSinceLastRecource = Time.time;
        }
    }
    
    public void TakeDamage(float damage) {
        lastdamageTaken = true;
        float f = ((Mathf.Sin(Time.time * flashspeed) + 1) * 0.5f);
        sr.material.SetFloat("_FlashAmount", f);

        bugHealth -= damage;
        if (bugHealth < 0) {
            GetComponent<EaterList>().NotifyEaters();
            Destroy(gameObject);
            //return true;
        }
        //return false;
    }
}
