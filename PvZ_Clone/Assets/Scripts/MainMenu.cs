using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject crazydoc;
    public AudioClip clicksound;

    public void PlayGame() {
        AudioSource.PlayClipAtPoint(clicksound, Camera.main.transform.position);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame() {
        AudioSource.PlayClipAtPoint(clicksound, Camera.main.transform.position);
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
