using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

    Levels lvl;

    public ScriptableObjectClass levelData;

    public LayerMask recource;

    GameObject[] lanes;

    public Transform spawnFolder;

    public GameObject resourcePrefab;
    public GameObject PauseMenu;

    public float roundOverallTimer = 60f;
    public float roundTimer = 60f;

    public float[] enemySpawnInterval;
    public float[] lastEnemySpawn;
    public GameObject[] enemies;

    public float resourceAmount = 0f;
    public float resourceSpawn;
    float timeSinceLastResource = 0f;

    float waveDelay = 10f;
    public int levelEnemyPool;
    int killableEnemiesLeft;
    bool spawningOnOff = true;

    public Text resourceText;
    public Text countdownText;
    public Animator leveloverview;

    bool paused = false;
    int countdownCounter = 3;

    void Start() {
        lanes = GameObject.FindGameObjectsWithTag("Lane");
        AtGameStart();
    }

    void ShowCountdown() {
        if (countdownCounter <= 3) {
            countdownText.text = ("3");
        }
        if (countdownCounter <= 2) {
            countdownText.text = ("2");
        }
        if (countdownCounter <= 1) {
            countdownText.text = ("1");
        }
        if (countdownCounter == 0) {
            countdownText.text = ("GO!");
        }
        if (countdownCounter < 0) {
            countdownText.text = ("");
        }
        countdownCounter--;
    }

    void AtGameStart() {
        Invoke("ShowCountdown", 7f);
        Invoke("ShowCountdown", 8f);
        Invoke("ShowCountdown", 9f);
        Invoke("ShowCountdown", 10f);
        Invoke("ShowCountdown", 11.5f);

        leveloverview.Play("LevelOverview");
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
        print("resource hit");
        resourceAmount += 25f;
        UpdateResourceAmountText();
        print(resourceAmount);
    }

    public void UpdateResourceAmountText() {
        resourceText.text = "Resource\nAmount: \n" + resourceAmount;
    }

    void Update() {

        roundTimer -= Time.deltaTime;

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

        if (Time.time > resourceSpawn + timeSinceLastResource && spawningOnOff) {
            GameObject go = Instantiate(resourcePrefab, transform.position + X, transform.rotation);
            go.transform.parent = spawnFolder;
            timeSinceLastResource = Time.time;
        }

        EnemySpawn(levelData.enemySpawnInterval, ref levelData.lastEnemySpawn, levelData.levelEnemies, levelData.levelPool);

    }

    public void EnemySpawn(float[] enemySpawnInterval, ref float[] lastEnemySpawn, GameObject[] enemies, int levelPool) {
        if (levelPool >= 0) {
            for (int i = 0; i < enemySpawnInterval.Length; i++) {
                if (Time.time > enemySpawnInterval[i] + lastEnemySpawn[i] && spawningOnOff) {
                    GameObject go = Instantiate(enemies[i], lanes[Random.Range(0, 5)].transform.position, transform.rotation);
                    go.transform.parent = spawnFolder;
                    killableEnemiesLeft++;
                    levelPool--;
                    lastEnemySpawn[i] = Time.time;
                }
            }
        }
    }

    //void EnemySpawn() {
    //    if (levelEnemyPool != 0) {
    //        for (int i = 0; i < enemySpawnInterval.Length; i++) {
    //            if (Time.time > enemySpawnInterval[i] + lastEnemySpawn[i] && spawningOnOff) {
    //                GameObject go = Instantiate(enemies[i], lanes[Random.Range(0, 5)].transform.position, transform.rotation);
    //                go.transform.parent = spawnFolder;
    //                killableEnemiesLeft++;
    //                levelEnemyPool--;
    //                lastEnemySpawn[i] = Time.time;
    //            }
    //        }
    //    }
    //}

    public void EnemyKilled() {
        killableEnemiesLeft--;
        if (levelEnemyPool == 0 && killableEnemiesLeft == 0) {
            LevelComplete();
        }
    }

    void LevelComplete() {
        print("oot vitun mestari");
        Time.timeScale = 0f;

    }

    public void GameOver() {
        Time.timeScale = 0f;
    }

    //void Wave() {
    //    print("wave");
    //    spawningOnOff = false;
    //    waveDelay -= Time.deltaTime;
    //    int waveEnemies = 10;
    //    if (waveDelay < 0 && waveEnemies != 0) {
    //        for (int i = 0; i < enemySpawnInterval.Length; i++) {
    //            GameObject go = Instantiate(enemies[i], lanes[Random.Range(0, 5)].transform.position, transform.rotation);
    //            go.transform.parent = enemySpawnFolder;
    //            killableEnemiesLeft++;
    //            waveEnemies--;
    //            levelEnemyPool--;
    //            lastEnemySpawn[i] = Time.time;
    //            if (waveEnemies == 0) {
    //                spawningOnOff = true;
    //            }
    //        }
    //    }
    //}
}

