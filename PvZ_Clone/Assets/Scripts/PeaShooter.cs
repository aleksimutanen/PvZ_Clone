using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EaterList))]
public class PeaShooter : MonoBehaviour, Bug {
    
    public float bugHealth;
    public GameObject ammo;
    public GameObject freezeammo;
    public float firingspeed;
    float lastShot = 0f;
    public float maxRaycastDistance = 1f;
    public LayerMask enemyLayer;
    GameManager gm;
    Animator animator;
    public string shootanimation;
    public string dieanimation;
    public float flashspeed;
    SpriteRenderer sr;
    bool lastdamageTaken;
    public AudioSource shotsfx;
    public AudioSource death;
    public AudioClip[] screams;
    public float maxPitch;
    float origPitch;



    public void Shoot() {
        GameObject go = Instantiate(ammo, transform.position - new Vector3(-0.3f, 0.2f, 0f), transform.rotation);
        go.transform.parent = gm.spawnFolder;
        float randomPitch = Random.Range(origPitch, maxPitch);
        shotsfx.pitch = randomPitch; 
        shotsfx.Play();
    }

    public void ShootFreeze() {
        GameObject go = Instantiate(freezeammo, transform.position - new Vector3(-0.3f, 0.2f, 0f), transform.rotation);
        go.transform.parent = gm.spawnFolder;
        float randomPitch = Random.Range(origPitch, maxPitch);
        shotsfx.pitch = randomPitch;
        shotsfx.Play();
    }

    public void DestroyAfterAnimation() {
        Destroy(gameObject);
    }


    void Start() {
        gm = GameObject.FindObjectOfType<GameManager>();
        animator = GetComponent<Animator>();
        origPitch = shotsfx.pitch;
    }

    void Awake() {
        sr = GetComponent<SpriteRenderer>();
    }


    void FixedUpdate() {
        if (lastdamageTaken == false) {
            sr.material.SetFloat("_FlashAmount", 0);
        }
        lastdamageTaken = false;
    }

    void Update() {

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.right, out hit, Mathf.Infinity, enemyLayer)) {
            if (Time.time > firingspeed + lastShot) {
                animator.Play(shootanimation);
                lastShot = Time.time;
            }
        }
    }

    public void TakeDamage(float damage) {
        lastdamageTaken = true;
        bugHealth -= damage;
        float f = ((Mathf.Sin(Time.time * flashspeed) + 1) * 0.5f);
        sr.material.SetFloat("_FlashAmount", f);
        if (bugHealth <= 0) {
            //animator.Play(dieanimation);
            //int index = Random.Range(0, screamy.Length);
            //screamy[index].Play();
            //death.PlayOneShot(screams[Random.Range(0, screams.Length)]);
            AudioSource.PlayClipAtPoint( screams[ Random.Range(0, screams.Length) ], Camera.main.transform.position );
            GetComponent<EaterList>().NotifyEaters();
            Destroy(gameObject);
            
            //return true;
        }
        //return false;
    }

    
}
