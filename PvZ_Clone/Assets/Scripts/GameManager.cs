using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


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
    public float startingTime;

    public float[] enemySpawnInterval;
    public float[] lastEnemySpawn;
    public GameObject[] enemies;

    public float resourceClick = 25f;
    public float resourceAmount = 0f;
    public float resourceSpawn;
    float timeSinceLastResource = 0f;

    float[] waveSpawnInterval = new float[] { 1f };
    float waveDelay = 10f;
    float normalSpawnonly = 30f;
    public int waveEnemies;
    public int levelEnemyPool;
    public int killableEnemiesLeft;

    bool resourceSpawnOnOff = true;
    bool enemySpawningOnOff = false;
    bool basicSpawningOnly = true;

    public Text resourceText;
    public Text countdownText;
    public Text kpm;
    public Text swatterLives;
    public Text highscore;
    public TextMeshProUGUI newcountdownText;
    public Animator leveloverview;
    public GameObject buildPanel;

    public AudioSource crop;
    public AudioSource gameover;
    public AudioSource melody;
    public AudioSource perc;
    public AudioSource clear;
    public AudioSource chime;
    public AudioSource three;
    public AudioSource two;
    public AudioSource one;
    public AudioSource go;

    bool paused = false;
    int countdownCounter = 3;

    GameObject le;

    public Vector3 targetPos;

    public GameObject pdPrefab;
    PersistentDataStorage pd;
    public int swatterModeLivesLeft;
    public GameObject highscorePanel;
    public GameObject gameoverPanel;

    public bool Paused() {
        return paused;
    }

    void StartPauseOff() {
        paused = false;
    }

    public void SetTimeScaleNormal() {
        Time.timeScale = 1f;
    }
    void ShowBuildPanel() {
        buildPanel.SetActive(true);
    }

    void LevelMusic() {
        melody.Play();
        perc.Play();
    }

    

    void Start() {
        if (levelData.name == "LevelData1") {
            Time.timeScale = 0f;
        }
        Time.timeScale = 1f;
        lanes = GameObject.FindGameObjectsWithTag("Lane");
        pd = FindObjectOfType<PersistentDataStorage>();
        if (pd == null) {
            var pdp = Instantiate(pdPrefab);
            pd = pdp.GetComponent<PersistentDataStorage>();
        }
        AtGameStart();
    }

    void ShowCountdown() {
        if (countdownCounter <= 3) {
            newcountdownText.text = ("3");
            three.Play();
        }
        if (countdownCounter <= 2) {
            newcountdownText.text = ("2");
            two.Play();
            three.Stop();
        }
        if (countdownCounter <= 1) {
            newcountdownText.text = ("1");
            one.Play();
            two.Stop();
        }
        if (countdownCounter == 0) {
            newcountdownText.text = ("GO!");
            go.Play();
            one.Stop();
        }
        if (countdownCounter < 0) {
            newcountdownText.text = ("");
            one.Stop();
        }
        countdownCounter--;
    }

    public void AtGameStart() {
        paused = true;

        Invoke("ShowCountdown", 2f);
        Invoke("ShowBuildPanel", 2f);
        Invoke("ShowCountdown", 3f);
        
        Invoke("ShowCountdown", 4f);
        
        Invoke("ShowCountdown", 5f);
        
        Invoke("StartPauseOff", 6.5f);
        Invoke("ShowCountdown", 6.5f);
        Invoke("LevelMusic", 6.5f);

     
        //leveloverview.Play("LevelOverview");

        if (levelData.swatterMode) {
            startingTime = Time.time;
            swatterLives.text = "Lives left:\n" + swatterModeLivesLeft;
            highscore.text = "Highscore:\n" + pd.highScore;
            //highscorePanel.SetActive(false);
            //gameoverPanel.SetActive(false);
        }
        //leveloverview.Play("LevelOverview");
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

    public void ResourceClick() {
        //print("resource hit");
        crop.Play();
        resourceAmount += resourceClick;
        UpdateResourceAmountText();
        //print(resourceAmount);
        if (levelData.swatterMode) {
            if (resourceAmount > pd.highScore) {
                //pd.highScore = resourceAmount;
                highscore.text = "Highscore:\n" + pd.highScore;
                //Text.diibadaaba
            }
        }
    }

    public void NewAntClick() {
        print("New Ant");
        newAntScreen.SetActive(true);
    }

    public void UpdateResourceAmountText() {
        resourceText.text = "" + resourceAmount;
    }

    void Update() {

        if (Input.GetKeyDown(KeyCode.Escape)) {
            paused = TogglePaused();
        }

        if (paused)
            return;

        if (levelData.swatterMode) {
            kpm.text = "Swats per\n minute:\n" + (resourceAmount * 60) / (Time.time - startingTime);
            if (resourceSpawn >= 0.15f) { 
                for (int i = 0; i < levelData.swatterModeTimes.Length; i++) {
                    if (resourceSpawn >= levelData.swatterModeSpawnInterval[i]) {
                        if (Time.time - startingTime > levelData.swatterModeTimes[i]) {
                            resourceSpawn = levelData.swatterModeSpawnInterval[i];
                        }
                    }
                }
            }
        }

        if (levelData.swatterMode) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                SceneManager.LoadScene(6);
                Time.timeScale = 1f;
            }
        }

        //roundStartDelay -= Time.deltaTime;

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

        if (Time.time > resourceSpawn + timeSinceLastResource && resourceSpawnOnOff) {
            GameObject go = Instantiate(resourcePrefab, transform.position +
            new Vector3(Random.Range(-3f, 3f), Random.Range(2f, -2f), 0), transform.rotation);
            go.transform.parent = spawnFolder;
            timeSinceLastResource = Time.time;
        }

        normalSpawnonly -= Time.deltaTime;
        EnemySpawn(levelData.enemySpawnInterval, ref lastEnemySpawn, levelData.levelEnemies);

        if (normalSpawnonly < 0) {
            basicSpawningOnly = false;
            enemySpawningOnOff = true;
        }

        if (roundStartDelay < 0) {
            if (levelEnemyPool < waveEnemies) {
                waveDelay -= Time.deltaTime;
                enemySpawningOnOff = false;
                if (waveDelay < 0) {
                    Wave();
                }
            }
        }
    }

    public void EnemySpawn(float[] enemySpawnInterval, ref float[] lastEnemySpawn, GameObject[] enemies) {
        if (levelEnemyPool != 0) {
            for (int i = 0; i < enemySpawnInterval.Length; i++) {
                if (Time.time > enemySpawnInterval[i] + lastEnemySpawn[i] && enemySpawningOnOff) {
                    GameObject go = Instantiate(enemies[i], lanes[Random.Range(0, 5)].transform.position, lanes[0].transform.rotation);
                    go.transform.parent = spawnFolder;
                    killableEnemiesLeft++;
                    levelEnemyPool--;
                    lastEnemySpawn[i] = Time.time;
                } else if (Time.time > enemySpawnInterval[0] + lastEnemySpawn[0] && basicSpawningOnly) {
                    GameObject go = Instantiate(enemies[0], lanes[Random.Range(0, 5)].transform.position, lanes[0].transform.rotation);
                    go.transform.parent = spawnFolder;
                    killableEnemiesLeft++;
                    levelEnemyPool--;
                    lastEnemySpawn[0] = Time.time;
                }
            }
        }
    }

    public void EnemyKilled(Vector3 position) {
        killableEnemiesLeft--;
        if (killableEnemiesLeft <= 0 && levelEnemyPool == 0) {
            Instantiate(newAntCardPrefab, position, Quaternion.identity);
            LevelComplete();
        }
    }

    public void TickExplodes() {
        swatterModeLivesLeft--;
        swatterLives.text = "Lives left:\n" + swatterModeLivesLeft;
        if (swatterModeLivesLeft == 0) {
            GameOver();
        }
    }

    public void LevelComplete() {
        print("oot vitun mestari");
        resourceSpawnOnOff = false;
        melody.Stop();
        perc.Stop();
        clear.Play();
        chime.Play();
    }

    public void GameOver() {
        melody.Stop();
        perc.Stop();
        gameover.Play();
        if (levelData.swatterMode) {
            Time.timeScale = 0f;
            var b = FindObjectOfType<BuyableItems>();
            b.swatterButton.interactable = false;
            b.ResetCursor();
            if (resourceAmount > pd.highScore) {
                pd.highScore = resourceAmount;
                highscore.text = "Highscore:\n" + pd.highScore;
                highscorePanel.SetActive(true);
            } else {
                gameoverPanel.SetActive(true);
            }
        }
        Time.timeScale = 0f;
    }

    void Wave() {
        for (int i = 0; i < enemySpawnInterval.Length; i++) {
            if (levelEnemyPool != 0) {
                if (Time.time > waveSpawnInterval[0] + lastEnemySpawn[i]) {
                    GameObject go = Instantiate(levelData.levelEnemies[i], lanes[Random.Range(0, 5)].transform.position, transform.rotation);
                    go.transform.parent = spawnFolder;
                    killableEnemiesLeft++;
                    levelEnemyPool--;
                    lastEnemySpawn[i] = Time.time;
                }
            }
        }
    }
}


