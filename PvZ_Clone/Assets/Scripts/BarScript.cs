using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour {
    public Bugtype bug;

    public float fillAmount = 1f;
    public Image generatorContent;

    BuyableItems bi;
    Button button;

    private void Start() {
        bi = FindObjectOfType<BuyableItems>();
        button = GetComponent<Button>();
    }
    
    private void Update() {
        //if (bi.CooldownAvailable((int)bug)) {
        //    button.interactable = true;
        //} else {
        //    button.interactable = false;
        //}

        button.interactable = bi.CooldownAvailable((int)bug); // sama kuin yllä

        generatorContent.fillAmount = bi.CooldownPercentLeft((int)bug);

    }

    //public void CooldownTime () {
    //        generatorContent.fillAmount = fillAmount;
    //        fillAmount -= Time.deltaTime * timeAdjust;
    //    if (fillAmount == 0f) {
    //         readyToBuy = true;
    //    }
    //}
    //void HandleBar2() { 
    //    if (fillAmount > 0f) {
    //        basicContent.fillAmount = fillAmount;
    //        fillAmount -= Time.deltaTime * timeAdjust;
    //    }
    //}
}
