using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Bugtype {None, Basicshooter, Generator, Block, Mine}

public class BuyableItems : MonoBehaviour {

    public List<float> bugCooldowns;
    List<float> bugCooldownTimers;

    Bugtype nowplacing = Bugtype.None;
    public List<GameObject> ghostbugs;
    public LayerMask ground;
    public List<GameObject> bugPrefabs;

    private GameManager gm;
    
    // nappia klikkaamalla tietää että raahaa tiettyä itemiä


    public float CooldownPercentLeft(int bugID) {
        if (CooldownAvailable(bugID))
            return 0;
        return bugCooldownTimers[bugID - 1] / bugCooldowns[bugID - 1];
    }

    public bool CooldownAvailable(int bugID) {
        return bugCooldownTimers[bugID - 1] < 0f;
    }

   public void BuyBasicshooter() {
        if (gm.resourceAmount >= 100f /*&& bs.fillAmount <=0f*/) {
            Buy(Bugtype.Basicshooter);
        }
    }

    public void BuyGenerator() {
        if (gm.resourceAmount >= 50f /*&& bs.fillAmount <= 0f*/) {
            Buy(Bugtype.Generator);
        }
    }

    public void BuyBlock() {
        if (gm.resourceAmount >= 50f) {
            Buy(Bugtype.Block);
        }
    }

    public void BuyMine() {
        if (gm.resourceAmount >= 25f) {
            Buy(Bugtype.Mine);
        }
    }

    void Buy(Bugtype b) {
            nowplacing = b;
            int index = (int)b - 1;
            for (int i = 0; i < ghostbugs.Count; i++) {
                if (i == index) {
                    ghostbugs[i].SetActive(true);
                }
                else ghostbugs[i].SetActive(false);
        }
    }

     void Start() {
        gm = GameObject.FindObjectOfType<GameManager>();
        bugCooldownTimers = new List<float>(bugCooldowns);

    }

    void Update() {
        if (gm.Paused())
            return;

        for (int i = 0; i < bugCooldownTimers.Count; i++) {
            bugCooldownTimers[i] -= Time.deltaTime;
        }
        if (nowplacing != Bugtype.None) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground)) {
                int index = (int)nowplacing - 1;
                var snapped = new Vector3(Mathf.Round(hit.point.x), Mathf.Round(hit.point.y), -0.8f);
                ghostbugs[index].transform.position = snapped;
                if (Input.GetKeyDown(KeyCode.Mouse0)) {
                    if (!CooldownAvailable(index + 1))
                        Debug.LogError("Tried to place while cooldown not done");

                    //bs.fillamount = 1f;
                    var go = Instantiate(bugPrefabs[index]);
                    go.transform.position = snapped;
                    go.transform.parent = gm.spawnFolder;
                    ghostbugs[index].SetActive(false);
                    if (nowplacing == Bugtype.Basicshooter) {
                        gm.resourceAmount -= 100f;
                        gm.UpdateResourceAmountText();
                        print("cost 100 resource");
                        nowplacing = Bugtype.None;
                    }
                    if (nowplacing == Bugtype.Generator) {
                        gm.resourceAmount -= 50f;
                        gm.UpdateResourceAmountText();
                        print("cost 50 resource");
                        nowplacing = Bugtype.None;
                    }
                    if (nowplacing == Bugtype.Block) {
                        gm.resourceAmount -= 50f;
                        gm.UpdateResourceAmountText();
                        print("cost 50 resource");
                        nowplacing = Bugtype.None;
                    }
                    if (nowplacing == Bugtype.Mine) {
                        gm.resourceAmount -= 25f;
                        gm.UpdateResourceAmountText();
                        print("cost 25 resource");
                        nowplacing = Bugtype.None;
                    }
                    bugCooldownTimers[index] = bugCooldowns[index];


                } else if (Input.GetKeyDown(KeyCode.Mouse1)) {
                    // unplace selection
                    ghostbugs[index].SetActive(false);
                    nowplacing = Bugtype.None;
                }
            }

        }

    }
}

//Vector3 currentPos = new Vector3(Input.mousePosition.x - posX, Input.mousePosition.y - posY, dist.z);
//Vector3 worldPos = Camera.main.ScreenToWorldPoint(currentPos);
//transform.position = worldPos;

//public void PlayGame() {
//    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
//}

//public void QuitGame() {
//    print("Goodbye!");
//    Application.Quit();
//}