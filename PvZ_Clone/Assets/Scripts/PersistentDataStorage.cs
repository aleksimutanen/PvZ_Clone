using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentDataStorage : MonoBehaviour {

    public float highScore;

	void Start () {
        DontDestroyOnLoad(gameObject);
	}
}
