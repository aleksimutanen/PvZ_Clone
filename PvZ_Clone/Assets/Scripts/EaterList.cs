using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EaterList : MonoBehaviour {
    List<Bot> eaters;

    void Awake() {
        eaters = new List<Bot>();
    }

    public void RegisterEater(Bot b) {
        if (!eaters.Contains(b)) {
            eaters.Add(b);
        }
    }

    public void NotifyEaters() {
        foreach (Bot b in eaters) {
            b.NotifyBugEaten();
        }
    }
}
