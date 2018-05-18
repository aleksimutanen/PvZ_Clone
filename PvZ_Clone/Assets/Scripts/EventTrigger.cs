using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger : MonoBehaviour {

    public string eventinNimi;
    public string Music;


    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Fabric.EventManager.Instance.PostEvent(eventinNimi);
        }
        if (Input.GetKeyDown(KeyCode.P)) {
            Fabric.EventManager.Instance.PostEvent(Music);
        }
    }
}
