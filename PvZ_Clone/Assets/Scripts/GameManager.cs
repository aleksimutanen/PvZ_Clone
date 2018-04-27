using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public LayerMask recource;
    public GameObject recourcePrefab;
    public float recourceAmount = 0f;
    public float recourceSpawn;
    float timeSinceLastRecource = 0f;
    //float maxX;
    //float maxZ;
    //public Transform nr1;
    //public Transform nr2;
    Vector3 xAxis;
    Vector3 zAxis;
    //public Transform spawner;

    void Start () {
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, recource)) {
                print("recource hit");
                recourceAmount += 25f;
                print(recourceAmount);
                Destroy(hit.transform.gameObject);
            }
        }

        if (Time.time > recourceSpawn + timeSinceLastRecource) {
            Instantiate(recourcePrefab, transform.position, transform.rotation);
            timeSinceLastRecource = Time.time;
        }
		
	}
}
