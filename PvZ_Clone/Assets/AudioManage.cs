using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManage : MonoBehaviour {

    public AudioClip menuOversound;

    public void MenuOverSound() {
        AudioSource.PlayClipAtPoint(menuOversound, Camera.main.transform.position);
    }

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
