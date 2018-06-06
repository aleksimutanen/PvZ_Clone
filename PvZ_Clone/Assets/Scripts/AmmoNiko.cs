using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoNiko : MonoBehaviour {

    public float ammoDamage = 1f;
    public float ammospeed;
    public float ammoDuration;
    public GameObject recource;
    EnemyMovement em;
    int enemyLayer;
    public AudioSource hit;
    public AudioClip damage;
    public AudioSource freeze;
    public AudioClip ice;
    public float maxPitch;
    float origPitch;


    private void Start() {
        em = GetComponent<EnemyMovement>();
        enemyLayer = LayerMask.NameToLayer("Enemy");
        origPitch = hit.pitch;
    }

    void Update() {
        //transform.Translate(0, 0, ammospeed * Time.deltaTime);
        transform.position += Vector3.right * ammospeed * Time.deltaTime;
        ammoDuration -= Time.deltaTime;
        if(ammoDuration < 0) {
            Destroy(gameObject);
        }
    }


    //private void OnTriggerEnter(Collider other) {
    //    if (other.gameObject == !recource) {
    //        print("ammo hit");
    //        Destroy(gameObject);
    //    }
    //}
    // this is for without rigidbody

    void OnCollisionEnter(Collision collision) {
        var b = collision.gameObject.GetComponent<Bot>();
        if (gameObject.name == "Ammo(Clone)") {
            b.TakeDamage(ammoDamage);
            print("ammo hit");
            float randomPitch = Random.Range(origPitch, maxPitch);
            hit.pitch = randomPitch;
            AudioSource.PlayClipAtPoint(damage, Camera.main.transform.position);
            Destroy(gameObject);

        }
            if (/*collision.gameObject.layer == enemyLayer && */gameObject.name == "Ammo_Freezing(Clone)") {
            b.TakeDamage(ammoDamage);
            em = collision.gameObject.GetComponent<EnemyMovement>();
            em.state = EnemyState.Freezed;
            em.EnemyStatusStart(em.state);
            print("freezed hit");
            float randomPitch = Random.Range(origPitch, maxPitch);
            hit.pitch = randomPitch;
            AudioSource.PlayClipAtPoint(ice, Camera.main.transform.position);
            AudioSource.PlayClipAtPoint(damage, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }
}

