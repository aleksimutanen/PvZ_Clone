using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldFlash : MonoBehaviour {

    public float shieldHealth;
    public float hitfadespeed;

    SpriteRenderer sr;

    void Awake() {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update() {
        sr.color += Color.white * hitfadespeed * Time.deltaTime;
    }


    public bool TakeDamage(float damage) {
        shieldHealth -= damage;
        sr.color = Color.red;
        //Color c;
        //ColorUtility.TryParseHtmlString("0026FF", out c);
        //sr.color = c;

        if (shieldHealth <= 0) {
            Destroy(gameObject);
            return true;
        }
        return false;
        }
        
    }