using UnityEngine;
using System.Collections;

public class AoEAmmo : MonoBehaviour {

    public float ammoDamage = 1f;
    public float firingAngle = 45.0f;
    public float gravity = 9.8f;
    float duration = 5f;

    public GameObject Projectile;
    AoEShooter aoe;

    void Start() {
        aoe = FindObjectOfType<AoEShooter>();
        StartCoroutine(SimulateProjectile());
        Destroy(gameObject, 5f);
        //SimulateProjectile();
    }


    IEnumerator SimulateProjectile() {
        // Short delay added before Projectile is thrown
        yield return new WaitForSeconds(1.5f);

        // Move projectile to the position of throwing object + add some offset if needed.
        //Projectile.transform.position = transform.position + new Vector3(0, 0.0f, 0);

        // Calculate distance to target
        float target_Distance = Vector3.Distance(transform.position, aoe.target.transform.position);

        // Calculate the velocity needed to throw the object to the target at specified angle.
        float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);

        // Extract the X  Y componenent of the velocity
        float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

        // Calculate flight time.
        float flightDuration = target_Distance / Vx;

        // Rotate projectile to face the target.
        transform.rotation = Quaternion.LookRotation(aoe.target.transform.position - transform.position);

        float elapse_time = 0;

        while (elapse_time < flightDuration) {
            transform.Translate(0, (Vy - (gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);

            elapse_time += Time.deltaTime;

            yield return null;
        }
    }

    void OnCollisionEnter(Collision collision) {
        var b = collision.gameObject.GetComponent<Bot>();
        b.TakeDamage(ammoDamage);
        print("ammo hit");
        Destroy(gameObject);
    }
}


//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class AoEAmmo : MonoBehaviour {
//    public float ammoSpeed;
//    public float shotHighpoint;
//    public float initialDamage;
//    public float areaDamage;
//    public GameObject AoEShooter;
//    //public float middlePoint;
//    //public float hitPoint;
//    AoEShooter Shooter;

//void Start() {
//    //Shooter = GetComponent<AoEShooter>();
//}

//// Update is called once per frame
//void Update () {
//    //transform.Translate(middlePoint, shotHighpoint, ammoSpeed * Time.deltaTime);
//    transform.Translate(Shooter.middlePoint, 0, ammoSpeed * Time.deltaTime);

//    }

//void OnCollisionEnter(Collision collision) {
//    print("SPLASH!!!");
//    var b = collision.gameObject.GetComponent<Bot>();
//    b.TakeDamage(initialDamage);
//    Destroy(gameObject);
//}
//}
