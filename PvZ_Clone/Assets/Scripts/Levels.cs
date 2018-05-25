using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LevelSelected { Menu, Level1, Level2, Level3 };

public class Levels : MonoBehaviour {

    ScriptableObjectClass levelData;

    public LevelSelected level;

	void Start () {
        level = LevelSelected.Level1;
        LevelSelectedStart(level);
    }

    public void SetLevelNumber(LevelSelected newLevel) {
        LevelSelectedEnd(level);
        LevelSelectedStart(newLevel);
        level = newLevel;
    }

    public void LevelSelectedStart(LevelSelected starting) {
        if (starting == LevelSelected.Level1) {

        }
    }

    public void LevelSelectedEnd(LevelSelected ending) {
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
