using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Bugtype {None, Basicshooter, Generator, Block}

public class BuyableItems : MonoBehaviour {

    Bugtype nowplacing = Bugtype.None;
    public List<GameObject> ghostbugs;
    public LayerMask ground;
    public List<GameObject> bugPrefabs;

    public GameObject peashooter;
    // nappia klikkaamalla tietää että raahaa tiettyä itemiä

   public void BuyBasicshooter() {
        Buy(Bugtype.Basicshooter);
    }

    public void BuyGenerator() {
        Buy(Bugtype.Generator);
    }

    void Buy(Bugtype b) {
       {
            nowplacing = b;
            int index = (int)b - 1;
            for (int i = 0; i < ghostbugs.Count; i++) {
                if (i == index) {
                    ghostbugs[i].SetActive(true);
                }
                else ghostbugs[i].SetActive(false);
                
            }
            // muutetaan kursori placing cursoriin tms.
            //print("jejj");
           
        }
    }
	void Update () {
        if (nowplacing != Bugtype.None) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground)) {
                int index = (int)nowplacing - 1;
                var snapped = new Vector3(Mathf.Round(hit.point.x), 0, Mathf.Round(hit.point.z));
                ghostbugs[index].transform.position = snapped;
                if (Input.GetKeyDown(KeyCode.Mouse0)) {
                    var go = Instantiate(bugPrefabs[index]);
                    go.transform.position = snapped;
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