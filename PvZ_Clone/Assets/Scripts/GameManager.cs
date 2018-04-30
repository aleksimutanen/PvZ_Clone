using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public LayerMask recource;

    GameObject[] lanes;

    public GameObject recourcePrefab;
    public GameObject basicEnemy;
    public GameObject durableEnemy;
    public GameObject fastEnemy;

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


     void Start () {
        lanes = GameObject.FindGameObjectsWithTag("Lane");
     }

    void OnGUI() {

        if (paused) {
            if (Input.GetKeyDown(KeyCode.KeypadEnter)) {
                paused = togglePause();
            }
        }
    }

    bool togglePause() {

        if (Time.timeScale == 0f) {
            Time.timeScale = 1f;
            return (false);
        } else {
            Time.timeScale = 0f;
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

        if (Time.time > recourceSpawn + timeSinceLastRecource && spawningOnOff) {
            Instantiate(recourcePrefab, transform.position, transform.rotation);
            timeSinceLastRecource = Time.time;
        }

        if (Time.time > basicEnemySpawn + timeSinceLastBasic && spawningOnOff) {
            Instantiate(basicEnemy, lanes[Random.Range(0, 5)].transform.position, transform.rotation);
            timeSinceLastBasic = Time.time;
        }

        if (Time.time > durableEnemySpawn + timeSinceLastDurable && spawningOnOff) {
            Instantiate(durableEnemy, lanes[Random.Range(0, 5)].transform.position, transform.rotation);
            timeSinceLastDurable = Time.time;
        }

        if (Time.time > fastEnemySpawn + timeSinceLastFast && spawningOnOff) {
            Instantiate(fastEnemy, lanes[Random.Range(0, 5)].transform.position, transform.rotation);
            timeSinceLastFast = Time.time;
        }

        if (roundTimer < 30f) {
            Wave();
        }
    }

    public void GameOver() {
        Time.timeScale = 0f;
    }

    void Wave() {
        spawningOnOff = false;
    }
}

