using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Inventory/List", order = 1)]
public class ScriptableObjectClass : ScriptableObject {

    public GameObject[] Wave1;
    public GameObject[] Wave2;
    public GameObject[] Wave3;
}
