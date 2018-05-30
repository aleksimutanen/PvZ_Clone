using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject crazydoc;

    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame() {
        print("Goodbye!");
        Application.Quit();
    }

    public void CrazyDoc() {
        crazydoc.SetActive(true);
    }

    public void NextLevel() {
        print("next level load");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void RetryLevel() {
        print("retrylvl");
        // lataa sama lvl uudestaan
    }

    public void ResumeGame() {
        print("palaa pelaamaan");
        // palaa takaisin peliin
    }
}
