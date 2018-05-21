using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

    public ScriptableObjectClass levelData;

    public LayerMask resource;
    public LayerMask newAnt;

    GameObject[] lanes;

    public Transform spawnFolder;

    public GameObject resourcePrefab;
    public GameObject PauseMenu;
    public GameObject newAntCardPrefab;
    public GameObject newAntScreen;

    public float roundStartDelay;

    public float[] enemySpawnInterval;
    public float[] lastEnemySpawn;
    public GameObject[] enemies;

    public float resourceAmount = 0f;
    public float resourceSpawn;
    float timeSinceLastResource = 0f;

    float waveDelay = 10f;
    public int waveEnemies;
    public int levelEnemyPool;
    public int killableEnemiesLeft;

    bool resourceSpawnOnOff = true;
    bool enemySpawningOnOff = true;

    public Text resourceText;
    public Text countdownText;
    public Animator leveloverview;
    public GameObject buildPanel;

    bool paused = false;
    int countdownCounter = 3;

    GameObject le;

    public Vector3 targetPos;


    public bool Paused() {
        return paused;
    }

    void StartPauseOff() {
        paused = false;
    }
    void ShowBuildPanel() {
        buildPanel.SetActive(true);
    }

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
        paused = true;

        Invoke("ShowCountdown", 7f);
        Invoke("ShowBuildPanel", 7f);
        Invoke("ShowCountdown", 8f);
        Invoke("ShowCountdown", 9f);
        Invoke("ShowCountdown", 10f);
        Invoke("StartPauseOff", 11.5f);
        Invoke("ShowCountdown", 11.5f);

        leveloverview.Play("LevelOverview");
    }

    void OnGUI() {

        if (paused) {
            if (Input.GetKeyDown(KeyCode.KeypadEnter)) {
                paused = TogglePaused();
            }
        }
    }

    public bool TogglePaused() {

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
    public void NewAntClick() {
        print("New Ant");
        newAntScreen.SetActive(true);
        //Time.timeScale = 0f;
    }

    public void UpdateResourceAmountText() {
        resourceText.text = "Resource\nAmount: \n" + resourceAmount;
    }

    void Update() {

        targetPos = new Vector3(Random.Range(-3f, 3f), Random.Range(0f, -3f), 0);

        if (Input.GetKeyDown(KeyCode.Escape)) {
            paused = TogglePaused();
        }

        if (paused)
            return;

        le = GameObject.FindGameObjectWithTag("Enemy");
        roundStartDelay -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, resource)) {
                ResourceClick();
                Destroy(hit.transform.gameObject);
            }
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, newAnt)) {
                NewAntClick();
                Destroy(hit.transform.gameObject);
            }
        }

        Vector3 spawnPoint = new Vector3(0, 5, 0);

        if (Time.time > resourceSpawn + timeSinceLastResource && resourceSpawnOnOff) {
            GameObject go = Instantiate(resourcePrefab, transform.position + targetPos + spawnPoint, transform.rotation);
            go.transform.parent = spawnFolder;
            timeSinceLastResource = Time.time;
        }

        EnemySpawn(levelData.enemySpawnInterval, ref lastEnemySpawn, levelData.levelEnemies);

        if (roundStartDelay < 0) {
            if (levelEnemyPool < waveEnemies) {
                waveDelay -= Time.deltaTime;
                enemySpawningOnOff = false;
                if (waveDelay < 0) {
                    Wave();
                }
                //        //if (roundTimer < roundOverallTimer / 2) {
                //        //    Wave();
                //        //    spawningOnOff = false;
                //        //}
                //    }
                //}
            }
        }
    }

    public void EnemySpawn(float[] enemySpawnInterval, ref float[] lastEnemySpawn, GameObject[] enemies) {
        if (levelEnemyPool != 0) {
            for (int i = 0; i < enemySpawnInterval.Length; i++) {
                if (Time.time > enemySpawnInterval[i] + lastEnemySpawn[i] && enemySpawningOnOff) {
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
            if (killableEnemiesLeft == 0 && levelEnemyPool == 0) {
                //resourceSpawnOnOff = false;
                Instantiate(newAntCardPrefab, le.transform.position, le.transform.rotation);
                LevelComplete();
            }
        }

        public void LevelComplete() {
            print("oot vitun mestari");
            resourceSpawnOnOff = false;

        }

        public void GameOver() {
            Time.timeScale = 0f;
        }

    void Wave() {
        for (int i = 0; i < enemySpawnInterval.Length; i++) {
            if (levelEnemyPool != 0) {
                GameObject go = Instantiate(levelData.levelEnemies[i], lanes[Random.Range(0, 5)].transform.position, transform.rotation);
                go.transform.parent = spawnFolder;
                killableEnemiesLeft++;
                levelEnemyPool--;
                lastEnemySpawn[i] = Time.time;
            }
        }
    }
}


