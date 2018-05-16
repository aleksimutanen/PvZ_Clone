using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame() {
        print("Goodbye!");
        Application.Quit();
    }

    public void NextLevel() {
        print("next level load");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
}
