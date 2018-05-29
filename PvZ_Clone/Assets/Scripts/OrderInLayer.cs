using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderInLayer : MonoBehaviour {

    SpriteRenderer sr;
    private void Awake() {
        sr = GetComponent<SpriteRenderer>();
        sr.sortingOrder = 100 * (-Mathf.RoundToInt(transform.position.y) + 3) + Random.Range(0,50);

    }
    void Update () {

        //sr.sortingOrder = 100 * (-Mathf.RoundToInt(transform.position.y) + 3) - Mathf.RoundToInt(transform.position.x*10);

        //if (transform.position.y == -2f) {
        //    sr.sortingOrder = 5;
        //}
        //if (transform.position.y == -1f) {
        //    sr.sortingOrder = 4;
        //}
        //if (transform.position.y == 0f) {
        //    sr.sortingOrder = 3;
        //}
        //if (transform.position.y == 1f) {
        //    sr.sortingOrder = 2;
        //}
        //if (transform.position.y == 2f) {
        //    sr.sortingOrder = 1;
        //}

    }

}
