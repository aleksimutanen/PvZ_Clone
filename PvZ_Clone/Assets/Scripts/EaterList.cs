using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EaterList : MonoBehaviour {
    public List<Bot> eaters;

    void Awake() {
        eaters = new List<Bot>();
    }

    public void RegisterEater(Bot b) {
        if (!eaters.Contains(b)) {
            print("eater added");
            eaters.Add(b);
        }
    }

    public void NotifyEaters() {
        foreach (Bot b in eaters) {
            print("eaters notified");
            b.NotifyBugEaten();
        }
    }
}
