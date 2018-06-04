using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EaterList))]
public class Landmine : MonoBehaviour, Bug {

    public float triggeringTime;
    bool willExplode;
    public float givenDamage;
    int enemyLayer;
    public float bugHealth;

    public Sprite phase1;
    public Sprite phase2;
    public Sprite phase3;

    public GameObject splash;

    SpriteRenderer sr;
    public float flashspeed;
    bool lastdamageTaken;

    GameManager gm;

    void Awake () {
        sr = GetComponentInChildren<SpriteRenderer>();
        gm = FindObjectOfType<GameManager>();
    }

    // Use this for initialization
    void Start() {
        willExplode = false;
        enemyLayer = LayerMask.NameToLayer("Enemy");
    }

    void FixedUpdate() {
        if (lastdamageTaken == false) {
            sr.material.SetFloat("_FlashAmount", 0);
        }
        lastdamageTaken = false;
    }

    // Update is called once per frame
    void Update() {
        triggeringTime -= Time.deltaTime;

        if (triggeringTime < 0.5) {
            sr.sprite = phase2;
        }

        if (triggeringTime < 0) {
            sr.sprite = phase3;
            willExplode = true;
            if (gm.levelData.swatterMode) {
                gm.TickExplodes();
                var go = Instantiate(splash, transform.position, transform.rotation);
                Destroy(go, 1f);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (willExplode && other.gameObject.layer == enemyLayer) {
            // other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            print("explosion");
            var b = other.GetComponent<Bot>();
            //bool dead = b.TakeDamage(givenDamage);
            b.TakeDamage(givenDamage);
            //if (dead) {
            GetComponent<EaterList>().NotifyEaters();
            Destroy(gameObject);
                var go = Instantiate(splash, transform.position, transform.rotation);
                Destroy(go, 1f);
            }
        }
    
    public void TakeDamage(float damage) {
        lastdamageTaken = true;

        float f = ((Mathf.Sin(Time.time * flashspeed) + 1) * 0.5f);
        sr.material.SetFloat("_FlashAmount", f);

        bugHealth -= damage;
        if (bugHealth <= 0) {
            GetComponent<EaterList>().NotifyEaters();
            Destroy(gameObject);
            //return true;
        }
        //return false;
    }
}
