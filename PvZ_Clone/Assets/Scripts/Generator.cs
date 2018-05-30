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

    void Start() {
        gm = FindObjectOfType<GameManager>();
    }

    void Update() {

        if (Time.time > recourceSpawn + timeSinceLastRecource) {
            GameObject go = Instantiate(recourcePrefab, dropPosition.transform.position, transform.rotation);
            go.transform.parent = gm.spawnFolder;
            timeSinceLastRecource = Time.time;
        }
    }
    
    public void TakeDamage(float damage) {
        bugHealth -= damage;
        if (bugHealth < 0) {
            Destroy(gameObject);
            //return true;
        }
        //return false;
    }
}
