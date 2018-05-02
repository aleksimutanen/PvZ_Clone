using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Bugtype {None, Basicshooter, Generator, Block}

public class BuyableItems : MonoBehaviour {

    Bugtype nowplacing = Bugtype.None;
    public List<GameObject> ghostbugs;

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
		
	}
}


//public void PlayGame() {
//    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
//}

//public void QuitGame() {
//    print("Goodbye!");
//    Application.Quit();
//}