using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntTakeHit : MonoBehaviour {

    SpriteRenderer sr;
    public Color neutral;
    public Color highlight;
    public float flashspeed;

	void Awake () {
        sr = GetComponent<SpriteRenderer>();
	}
	
	void Update () {
        sr.color += Color.white * Time.deltaTime;


        float f = (Mathf.Sin(Time.time * flashspeed) + 1 * 0.5f);
        sr.color = Color.Lerp(neutral, highlight, f);

    }
}
