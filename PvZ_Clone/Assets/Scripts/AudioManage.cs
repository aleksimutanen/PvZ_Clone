using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManage : MonoBehaviour {

    public AudioClip menuOversound;
    public AudioClip selectSound;
    public AudioClip buttonDown;
    public AudioClip buttonUp;


    public void MenuOverSound() {
        AudioSource.PlayClipAtPoint(menuOversound, Camera.main.transform.position);
    }

    public void SelectSound() {
        AudioSource.PlayClipAtPoint(selectSound, Camera.main.transform.position);
    }

    public void ButtonDown() {
        AudioSource.PlayClipAtPoint(buttonDown, Camera.main.transform.position);
    }

    public void ButtonUp() {
        AudioSource.PlayClipAtPoint(buttonUp, Camera.main.transform.position);
    }


	

}
