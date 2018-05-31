using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntTakeHit : MonoBehaviour {

    SpriteRenderer sr;
    //public Color neutral;
    //public Color highlight;
    public float flashspeed;

	void Awake () {
        sr = GetComponent<SpriteRenderer>();
	}
	
	void Update () {
        float f = ((Mathf.Sin(Time.time * flashspeed) + 1) * 0.5f);
        sr.material.SetFloat("_FlashAmount", f);

        //float f = ((Mathf.Sin(Time.time * flashspeed) + 1) * 0.5f);
        //if (sr.color != Color.blue) {
        //    print("jee");
        //}
        //ac.enabled = false;
        //sr.color = Color.blue;
        //ac.enabled = true;
        //sr.color = Color.Lerp(neutral, highlight, f);

    }
}
