using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject crazydoc;
    public AudioClip clicksound;
    public Animator animator;
    public string extramenuDrop;

    public void PlayGame() {
        AudioSource.PlayClipAtPoint(clicksound, Camera.main.transform.position);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void PlaySwatter() {
        //scenenro joka swatterilla on
        SceneManager.LoadScene(6);
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // lataa sama lvl uudestaan
    }

    public void ResumeGame() {
        print("palaa pelaamaan");
        Time.timeScale = 1f;
        // palaa takaisin peliin
    }

    public void QuitToMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
