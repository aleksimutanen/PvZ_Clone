using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Leveldata", menuName = "Leveldata", order = 1)]
public class ScriptableObjectClass : ScriptableObject {

    public float[] enemySpawnInterval;
    public float[] lastEnemySpawn;
    public int levelPool;
    public GameObject[] levelEnemies;

    public GameObject[] Wave1;
    public GameObject[] Wave2;
    public GameObject[] Wave3;
}


