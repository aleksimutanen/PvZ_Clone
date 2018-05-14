using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public LayerMask recource;

    GameObject[] lanes;

    public ScriptableObjectClass waveData;
    List<GameObject[]> waves;

    public Transform spawnFolder;

    public GameObject recourcePrefab;
    public GameObject PauseMenu;

    public float levelCountDown = 10f;
    public float roundTimer = 60f;

    public float[] enemySpawnInterval;
    public float[] lastEnemySpawn;
    public GameObject[] enemies;

    public float resourceAmount = 0f;
    public float resourceSpawnInterval;
    float timeSinceLastResource = 0f;

    public int waveEnemies;
    public int levelEnemyPool;
    int killableEnemiesLeft;
    bool spawningOnOff;

    public Text resourceText;

    bool paused = false;

    void Start() {
        spawningOnOff = false;
        lanes = GameObject.FindGameObjectsWithTag("Lane");
        //waves = new List<GameObject[]>();
        //waves.Add(waveData.Wave1);
        //waves.Add(waveData.Wave2);
        //waves.Add(waveData.Wave3);
        //levelEnemyPool = 0;
        //foreach (var wave in waves) {
        //    levelEnemyPool += wave.Length;
        //}
    }

    void OnGUI() {

        if (paused) {
            if (Input.GetKeyDown(KeyCode.KeypadEnter)) {
                paused = togglePause();
            }
        }
    }

    public bool togglePause() {

        if (Time.timeScale == 0f) {
            Time.timeScale = 1f;
            PauseMenu.SetActive(false);
            return (false);
        } else {
            Time.timeScale = 0f;
            PauseMenu.SetActive(true);
            return (true);
        }
    }

    void ResourceClick() {
        print("recource hit");
        resourceAmount += 25f;
        UpdateResourceAmountText();
        print(resourceAmount);
    }

    public void UpdateResourceAmountText() {
        resourceText.text = "Resource\nAmount: \n" + resourceAmount;
    }

    void Update() {

        levelCountDown -= Time.deltaTime;
        roundTimer -= Time.deltaTime;

        if (levelCountDown <= 0) {
            spawningOnOff = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            paused = togglePause();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, recource)) {
                ResourceClick();
                Destroy(hit.transform.gameObject);
            }
        }

        Vector3 X = new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(-2f, 2f), 0);

        if (Time.time > resourceSpawnInterval + timeSinceLastResource) {
            GameObject go = Instantiate(recourcePrefab, transform.position + X, transform.rotation);
            go.transform.parent = spawnFolder;
            timeSinceLastResource = Time.time;
        }

        EnemySpawn();

        if (roundTimer < 10f) {
            //Wave();
        }
    }

    void EnemySpawn() {
        if (levelEnemyPool >= 0) {
            for (int i = 0; i < enemySpawnInterval.Length; i++) {
                if (Time.time > enemySpawnInterval[i] + lastEnemySpawn[i] && spawningOnOff) {
                    GameObject go = Instantiate(enemies[i], lanes[Random.Range(0, 5)].transform.position, transform.rotation);
                    go.transform.parent = spawnFolder;
                    killableEnemiesLeft++;
                    levelEnemyPool--;
                    lastEnemySpawn[i] = Time.time;
                }
            }
        }
    }

    public void EnemyKilled() {
        killableEnemiesLeft--;
        if (levelEnemyPool <= 0 && killableEnemiesLeft <= 0) {
            LevelComplete();
        }
    }

    void LevelComplete() {
        print("oot mestari");
        Time.timeScale = 0f;
    }

    public void GameOver() {
        Time.timeScale = 0f;
    }

    //void Wave() {
    //    for (int i = 0; i < waveData.lvl1_Wave.Length; i++) {
    //        GameObject go = Instantiate(waveData.lvl1_Wave[i], lanes[Random.Range(0, 5)].transform.position, transform.rotation);
    //        go.transform.parent = spawnFolder;
    //        killableEnemiesLeft++;
    //        levelEnemyPool--;
    //        //Instantiate(waveData.lvl1_Wave[i]);
    //    }
    //}

    //void Wave() {
    //    print("wave");
    //    spawningOnOff = false;
    //    waveDelay -= Time.deltaTime;
    //    waveEnemies = 10;
    //    if (waveEnemies >= 0) {
    //        for (int i = 0; i < enemySpawnInterval.Length; i++) {
    //            if (waveDelay < 0) {
    //                GameObject go = Instantiate(enemies[i], lanes[Random.Range(0, 5)].transform.position, transform.rotation);
    //                go.transform.parent = enemySpawnFolder;
    //                killableEnemiesLeft++;
    //                waveEnemies--;
    //                levelEnemyPool--;
    //                //if (waveEnemies == 0) {
    //                //    spawningOnOff = true;
    //                //}
    //            }
    //        }
    //    }
    //}
}

