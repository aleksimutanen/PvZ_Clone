using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public LayerMask recource;

    GameObject[] lanes;

    public Transform enemyFolder;

    public GameObject recourcePrefab;
    public GameObject basicEnemy;
    public GameObject durableEnemy;
    public GameObject fastEnemy;
    public GameObject PauseMenu;

    public float roundTimer = 60f;

    public float recourceAmount = 0f;
    public float recourceSpawn;
    float timeSinceLastRecource = 0f;

    public float basicEnemySpawn;
    float timeSinceLastBasic;

    public float durableEnemySpawn;
    float timeSinceLastDurable;

    public float fastEnemySpawn;
    float timeSinceLastFast;

    bool spawningOnOff = true;

    bool paused = false;

    void Start() {
        lanes = GameObject.FindGameObjectsWithTag("Lane");
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

    void Update() {

        roundTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Escape)) {
            paused = togglePause();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, recource)) {
                print("recource hit");
                recourceAmount += 25f;
                print(recourceAmount);
                Destroy(hit.transform.gameObject);
            }
        }

        Vector3 X = new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(-2.5f, 2.5f), 0);

        if (Time.time > recourceSpawn + timeSinceLastRecource && spawningOnOff) {
            Instantiate(recourcePrefab, transform.position + X, transform.rotation);
            timeSinceLastRecource = Time.time;
        }

        EnemySpawn(basicEnemySpawn, ref timeSinceLastBasic, basicEnemy);
        EnemySpawn(durableEnemySpawn, ref timeSinceLastDurable, durableEnemy);
        EnemySpawn(fastEnemySpawn, ref timeSinceLastFast, fastEnemy);

        //if (Time.time > basicEnemySpawn + timeSinceLastBasic && spawningOnOff) {
        //    GameObject go = Instantiate(basicEnemy, lanes[Random.Range(0, 4)].transform.position, transform.rotation);
        //    go.transform.parent = enemyFolder;
        //    timeSinceLastBasic = Time.time;
        //}

        //if (Time.time > durableEnemySpawn + timeSinceLastDurable && spawningOnOff) {
        //    GameObject go = Instantiate(durableEnemy, lanes[Random.Range(0, 4)].transform.position, transform.rotation);
        //    go.transform.parent = enemyFolder;
        //    timeSinceLastDurable = Time.time;
        //}

        //if (Time.time > fastEnemySpawn + timeSinceLastFast && spawningOnOff) {
        //    GameObject go = Instantiate(fastEnemy, lanes[Random.Range(0, 4)].transform.position, transform.rotation);
        //    go.transform.parent = enemyFolder;
        //    timeSinceLastFast = Time.time;
        //}

        //if (roundTimer < 30f) {
        //    Wave();
        //}
    }

    void EnemySpawn(float x, ref float y, GameObject enemy) {
        if (Time.time > x + y && spawningOnOff) {
            GameObject go = Instantiate(enemy, lanes[Random.Range(0, 5)].transform.position, transform.rotation);
            go.transform.parent = enemyFolder;
            y = Time.time;
        }
    }

    public void GameOver() {
        Time.timeScale = 0f;
    }

    void Wave() {
        spawningOnOff = false;
    }
}

