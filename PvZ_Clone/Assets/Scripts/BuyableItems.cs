using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum UIMode {None, Flyswatter, Basicshooter, Generator, Block, Mine, Freeze}

public class BuyableItems : MonoBehaviour {

    public List<float> bugCooldowns;
    List<float> bugCooldownTimers;

    public UIMode nowplacing = UIMode.None;
    public List<GameObject> ghostbugs;
    public LayerMask ground;
    public LayerMask bug;
    public List<GameObject> bugPrefabs;
    public Button swatterButton;
    public AudioSource press;
    public AudioSource place;

    public Texture2D cursorTexture;
    Vector2 hotspot = Vector2.zero;
    CursorMode cm = CursorMode.ForceSoftware;

    //public bool swatterMode;

    private GameManager gm;

    // nappia klikkaamalla tietää että raahaa tiettyä itemiä

    public float CooldownPercentLeft(UIMode bug) {
        if (CooldownAvailable(bug))
            return 0;
        int idx = (int)bug - 2;
        return bugCooldownTimers[idx] / bugCooldowns[idx];
    }

    public bool CooldownAvailable(UIMode bug) {
        int idx = (int)bug - 2;
        if (idx < 0)
            Debug.LogError("not a bug, no cooldown");
        return bugCooldownTimers[idx] < 0f;
    }

   public void BuyBasicshooter() {
        if (gm.resourceAmount >= 100f /*&& bs.fillAmount <=0f*/) {
            Buy(UIMode.Basicshooter);
            
        }
    }

    public void BuyGenerator() {
        if (gm.resourceAmount >= 50f /*&& bs.fillAmount <= 0f*/) {
            Buy(UIMode.Generator);
            
        }
    }

    public void BuyBlock() {
        if (gm.resourceAmount >= 50f) {
            Buy(UIMode.Block);
            
        }
    }

    public void BuyMine() {
        if (gm.resourceAmount >= 25f) {
            Buy(UIMode.Mine);
            
        }
    }
    
    public void BuyFreeze() {
        if (gm.resourceAmount >= 175f) {
            Buy(UIMode.Freeze);
            
        }
    }

    public void Flyswatter() {
        nowplacing = UIMode.Flyswatter;
        Cursor.SetCursor(cursorTexture, hotspot, cm);
        //Cursor.
        // TODO
        foreach (var gb in ghostbugs) {
            gb.SetActive(false);
        }
    }

    void Buy(UIMode b) {
            nowplacing = b;
            int index = (int)b - 2;
            for (int i = 0; i < ghostbugs.Count; i++) {
                if (i == index) {
                    ghostbugs[i].SetActive(true);
                }
                else ghostbugs[i].SetActive(false);
        }
    }

     void Start() {
        swatterButton.interactable = true;
        Cursor.SetCursor(null, hotspot, cm);
        gm = GameObject.FindObjectOfType<GameManager>();
        bugCooldownTimers = new List<float>(bugCooldowns);
        //cursorTexture.Resize(2000, 2000);
    }

    void Update() {
        if (gm.Paused())
            return;

        for (int i = 0; i < bugCooldownTimers.Count; i++) {
            bugCooldownTimers[i] -= Time.deltaTime;
        }
        if (nowplacing != UIMode.None && nowplacing != UIMode.Flyswatter) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground)) {
                int index = (int)nowplacing - 2;
                var snapped = new Vector3(Mathf.Round(hit.point.x), Mathf.Round(hit.point.y), -0.8f);
                ghostbugs[index].transform.position = snapped;
                Collider[] b /*tai var b*/ = Physics.OverlapSphere(snapped, 0.45f, bug);
                if (Input.GetKeyDown(KeyCode.Mouse0) && b.Length == 0) {
                    if (!CooldownAvailable(nowplacing))
                        Debug.LogError("Tried to place while cooldown not done");

                    //bs.fillamount = 1f;
                    var go = Instantiate(bugPrefabs[index]);
                    go.transform.position = snapped;
                    go.transform.parent = gm.spawnFolder;
                    ghostbugs[index].SetActive(false);
                    if (nowplacing == UIMode.Basicshooter) {
                        gm.resourceAmount -= 100f;
                        gm.UpdateResourceAmountText();
                        print("cost 100 resource");
                        nowplacing = UIMode.None;
                        place.Play();
                    }
                    if (nowplacing == UIMode.Generator) {
                        gm.resourceAmount -= 50f;
                        gm.UpdateResourceAmountText();
                        print("cost 50 resource");
                        nowplacing = UIMode.None;
                        place.Play();
                    }
                    if (nowplacing == UIMode.Block) {
                        gm.resourceAmount -= 50f;
                        gm.UpdateResourceAmountText();
                        print("cost 50 resource");
                        nowplacing = UIMode.None;
                        place.Play();
                    }
                    if (nowplacing == UIMode.Mine) {
                        gm.resourceAmount -= 25f;
                        gm.UpdateResourceAmountText();
                        print("cost 25 resource");
                        nowplacing = UIMode.None;
                        place.Play();
                    }
                    if (nowplacing == UIMode.Freeze) {
                        gm.resourceAmount -= 175f;
                        gm.UpdateResourceAmountText();
                        print("cost 175 resource");
                        nowplacing = UIMode.None;
                        place.Play();
                    }
                    bugCooldownTimers[index] = bugCooldowns[index];

                } else if (Input.GetKeyDown(KeyCode.Mouse1)) {
                    // unplace selection
                    ghostbugs[index].SetActive(false);
                    nowplacing = UIMode.None;
                }
            }

        } else if (nowplacing == UIMode.Flyswatter && Input.GetKeyDown(KeyCode.Mouse0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, bug)) {
                hit.transform.gameObject.GetComponent<EaterList>().NotifyEaters();
                print("swatted");
                Destroy(hit.transform.gameObject);
                if (gm.levelData.swatterMode == false) {
                    ResetCursor();
                } else if (gm.levelData.swatterMode == true) {
                    gm.ResourceClick();
                    //hit.transform.localScale = new Vector3(0, 0.1f, 0);
                    //nothing
                }
            }
            // jos on alla kasvi:
            // poistetaan
            // disabloidaan flyswatter
        } else if (nowplacing == UIMode.Flyswatter && Input.GetKeyDown(KeyCode.Mouse1)) {
            Cursor.SetCursor(null, hotspot, cm);
            nowplacing = UIMode.None;
        }
    }

    public void ResetCursor() {
        Cursor.SetCursor(null, hotspot, cm);
        nowplacing = UIMode.None;
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