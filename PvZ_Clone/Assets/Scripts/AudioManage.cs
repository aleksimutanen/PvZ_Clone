using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManage : MonoBehaviour {

    public AudioClip menuOversound;
    public AudioClip selectSound;
    public AudioClip buttonDown;
    public AudioClip buttonUp;
    public AudioClip bojoing;
    

    void Play(AudioClip ac) {
        var currentTS = Time.timeScale;
        Time.timeScale = 1f;
        AudioSource.PlayClipAtPoint(ac, Camera.main.transform.position);
        Time.timeScale = currentTS;
    }

    public void MenuOverSound() {
        Play(menuOversound);
    }

    public void SelectSound() {
        Play(selectSound);
    }

    public void ButtonDown() {
        Play(buttonDown);
    }

    public void ButtonUp() {
        Play(buttonUp);
    }

    public void MenuBojoing() {
        Play(bojoing);
    }


	

}
