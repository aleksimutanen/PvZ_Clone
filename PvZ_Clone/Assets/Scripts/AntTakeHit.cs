using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntTakeHit : MonoBehaviour {

    SpriteRenderer sr;
    public Color neutral;
    public Color highlight;
    public float flashspeed;
    Animator ac;

	void Awake () {
        sr = GetComponent<SpriteRenderer>();
        ac = GetComponent<Animator>();
	}
	
	void Update () {
        //sr.color += Color.white * Time.deltaTime;

        float f = ((Mathf.Sin(Time.time * flashspeed) + 1) * 0.5f);
        if (sr.color != Color.blue) {
            print("jee");
        }
        //ac.enabled = false;
        //sr.color = Color.blue;
        //ac.enabled = true;
        sr.color = Color.Lerp(neutral, highlight, f);

    }
}
