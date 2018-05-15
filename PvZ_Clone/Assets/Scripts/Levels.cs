using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LevelSelected { Menu, Level1, Level2, Level3 };

public class Levels : MonoBehaviour {


    LevelSelected level;

	void Start () {
        level = LevelSelected.Menu;
        LevelSelectedStart(level);
    }

    void SetLevelNumber(LevelSelected newLevel) {
        LevelSelectedEnd(level);
        LevelSelectedStart(newLevel);
        level = newLevel;
    }

    void LevelSelectedStart(LevelSelected starting) {
        if (starting != LevelSelected.Menu) {
        }
    }

    void LevelSelectedEnd(LevelSelected ending) {
        if (ending == LevelSelected.Menu) {
        }
    }

    public void Level1() {
        if (level == LevelSelected.Level1) {

        }
    }

    void Update () {
		
	}
}
