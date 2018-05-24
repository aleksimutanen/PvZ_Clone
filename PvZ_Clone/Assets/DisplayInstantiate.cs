using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayInstantiate : MonoBehaviour {

    GameManager gm;
    public Transform enemyOverviewfolder;
    public List<GameObject> EnemyList;

	void Start () {
        gm = GetComponent<GameManager>();	
	}
	
	void Update () {
        //GameObject go = Instantiate(displ)
        //    go.transform.parent = enemyOverviewfolder;
    }
}
