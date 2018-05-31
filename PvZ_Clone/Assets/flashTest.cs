using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashTest : MonoBehaviour {

    public float flashspeed;
    SpriteRenderer sr;

    private void Awake() {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update () {
        float f = ((Mathf.Sin(Time.time * flashspeed) + 1) * 0.5f);
        sr.material.SetFloat("_FlashAmount", f);

    }
}
