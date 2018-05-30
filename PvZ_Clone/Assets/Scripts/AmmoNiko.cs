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


    private void Start() {
        em = GetComponent<EnemyMovement>();
        enemyLayer = LayerMask.NameToLayer("Enemy");
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
            Destroy(gameObject);
        }
            if (/*collision.gameObject.layer == enemyLayer && */gameObject.name == "Ammo_Freezing(Clone)") {
            b.TakeDamage(ammoDamage);
            em = collision.gameObject.GetComponent<EnemyMovement>();
            em.state = EnemyState.Freezed;
            em.EnemyStatusStart(em.state);
            print("freezed hit");
            Destroy(gameObject);
        }
    }
}

