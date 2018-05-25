using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewAnt_smalltobig : MonoBehaviour {
    GameManager gm;

    private void Start() {
        gm = GetComponent<GameManager>();
    }
    void FixedUpdate() {
        if (transform.localScale.x < 1f)
       transform.localScale += new Vector3(0.8f, 0.8f, 0.8f) * Time.deltaTime;
        
    }
}
